import React, { Component } from 'react';

class Author extends Component {

    constructor(props) {
        super(props);
        this.state = {
            filteredBooks: props.books,
        }
    }

    filterBooks(filterText) {
        this.setState(Object.assign({}, this.state, {
            filteredBooks: this.props.books.filter(book =>
                book.toLowerCase().indexOf(filterText.toLowerCase()) >= 0)
        }));
    }

    render() {
        return <div>
            <input type="text" placeholder="Filter books"
                onChange={(event) => this.filterBooks(event.target.value)}></input>
            <ul>
                {this.state.filteredBooks.map(book => <li key={book}>{book}</li>)}
            </ul>
        </div>;
    }
}

export default Author;