# React

> To do this task you first need to complete the task [Web API](../Web%20API)

In this task we will modify the book list on the author page so that it is loaded using react.

## Preparations

1. It is recommended that you do the tutorials on [React](https://reactjs.org/tutorial/tutorial.html) and [Redux](https://redux.js.org/#learn-redux) that are linked on [docs](https://docs.litium.com/documentation/litium-accelerators/develop/front-end/working-with-javascript) to get an understanding of the core  concepts
1. Setup your local environment according to the [instructions on docs](https://docs.litium.com/documentation/litium-accelerators/develop/setting-up-the-development-environment) so that it monitors and rebuilds all scripts on every change

## Adjust Web API to read current data

Litium Accelerator is already set up to pass current page and channel in every request to the server, you can look at `Client\Scripts\Services\http.js` where the values are added in the header `litium-request-context` in every ajax-request.

To read the data from the `litium-request-context`-header in our Web API on the server we only need to inject `RequestModelAccessor` in the controller.

1. Inject `RequestModelAccessor` in the constructor of `AuthorApiController`
1. Create an overload to method `GetAuthor()` without the id-parameter and call the overloaded method using page-id from `RequestModel` : 
    ```C#
    [HttpGet]
    [Route("author")]
    public IHttpActionResult GetAuthor()
    {
        return GetAuthor(_requestModelAccessor.RequestModel.CurrentPageModel.SystemId);
    }
    ```

## Author listing with react

All changes in this section are done in folder `\Src\Litium.Accelerator.Mvc\Client\Scripts\` 

1. Add the actions that we will be working with, initially it is just a _load_-action that triggers a _receive_-action when it completes. Create the file `Actions\Author.action.js` with the code below. 
    ```JavaScript
    import { get } from '../Services/http';
    import { catchError } from './Error.action';

    export const AUTHOR_LOAD = 'AUTHOR_LOAD';
    export const AUTHOR_LOAD_ERROR = 'AUTHOR_LOAD_ERROR';
    export const AUTHOR_RECEIVE = 'AUTHOR_RECEIVE';

    export const load = () => (dispatch, getState) => {
        return get('/api/authors/author')
            .then(response => response.json())
            .then(data => dispatch(receive(data)))
            .catch(ex => dispatch(catchError(ex, error => loadError(error))))
    }

    export const loadError = error => ({
        type: AUTHOR_LOAD_ERROR,
        payload: {
            error,
        }
    })

    export const receive = data => {
        return ({
            type: AUTHOR_RECEIVE,
            payload: {
                books: data.books,
            },
        });
    } 

    ```
1. Create a component to render the author, create the file `\Components\Author.js` with the code below.
    ```JavaScript
    import React, { Component } from 'react';

    class Author extends Component {
        render() {
            // Render the books-property as a simple list.
            // A key is required by react to maintain the state (https://reactjs.org/docs/lists-and-keys.html)
            // For this basic example we just set the book title as key 
            return <ul>
                {this.props.books.map(book => <li key={book}>{book}</li>)}
            </ul>;
        }
    }

    export default Author;
    ```
1. Next add a container for the component, create the file `\Containers\Author.container.js` with the code below.
    ```JavaScript
    import React, { Component } from 'react';
    import { connect } from 'react-redux';
    import Author from '../Components/Author';
    import { load } from '../Actions/Author.action';

    class AuthorContainer extends Component {
        constructor(props) {
            super(props);
        }

        componentDidMount() {
            // This method is automatically triggering when component is loaded
            // we use it to call the load-action to init loading books.
            this.props.load();
        }

        render() {
            // Render the component
            return <Author {...this.props} />
        }
    }

    const mapStateToProps = state => {
        const { author } = state;
        return {
            ...author,
        }
    }

    const mapDispatchToProps = dispatch => {
        return {
            load: () => dispatch(load()),
        }
    }

    export default connect(mapStateToProps, mapDispatchToProps)(AuthorContainer);
    ```
1. Add a reducer that listens for new author data being received, create `Reducers\Author.reducer.js` with the code below. 
    ```JavaScript
    import { AUTHOR_RECEIVE } from '../Actions/Author.action';

    export const author = (state = { books: [] }, action) => {
        switch (action.type) {
            case AUTHOR_RECEIVE:
                return {
                    ...state,
                    ...action.payload,
                };
            default:
                return state;
        }
    }
    ```
1. Register the new reducer in `reducers.js`:
    ```JavaScript
    import { author } from './Reducers/Author.reducer'
    ```
    ```JavaScript
    const app = combineReducers({
        author,
        ...
    ```
1. Finally add the container-component to `bootstrapCompoents` in `index.js` to make it load on the author page.
    ```JavaScript
    import AuthorContainer from './Containers/Author.container'
    ```

    ```JavaScript
    const bootstrapComponents = () => {
        if (document.getElementById('author')) {
            ReactDOM.render(
                <Provider store={store}>
                    <AuthorContainer />
                </Provider>,
                document.getElementById('author')
            );
        }
        ...[other components here]
    ```

## Adjust template to render component

1. Above in `index.js` we added a script that look for an element where _id="author"_, so just replace the book listing in `\Litium.Accelerator.Mvc\Views\Author\Index.cshtml` with `<div id="author"></div>`

## Try it out

1. Your author page should now be loading books using React. Review the error log on the server and the console in the browser if no data is loaded to find any issues.

## Optional extra tasks

1. Add a textfield and use React to instantly filter the list of books as the user types (a working example of `Author.js` with filter can be found in the [_Resources_-folder](Resources/Author.js))
1. Extend the ViewModel passed from the API so that it contains a link to each book