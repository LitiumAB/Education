# Author field

> To do this task you first need to complete the task [Author page](../Author%20page)

Our client has to be able to connect books to authors so we need a field to define the link.

To create and connect this field to templates we will use the UI in Litium (but it could also be done in code in `Litium.Accelerator.Definitions.Products.ProductsFieldDefinitionSetup`).

> **IMPORTANT!** When you did the [_Author page_-task](../Author%20page) earlier you may have modified `DefinitionSetup` so that all templates are re-generated from code on every startup. Since this Author-field is only added in database and not in code it will get removed from the template when the application restarts if automatic re-create is enabled.

1. Open the Control panel in Litium backoffice and select _Products > Fields_ in left menu
1. Click _New_ and set:
   1. Type = **Pointer**
   1. Id = **AuthorField**
   1. Multi language = **No**
1. Save and edit the field, set:
   1. Entity = **Pages**
   1. Name = **Author** (for all languages)
1. Select _Products > Field templates_ in left menu
1. Make the following adjustment to every field template where _Type_=**Product**:
    1. Select the the fields-tab
    1. Add your new author-field to the _General_-fieldgroup

## Try it out

1. Select _Products_ in top menu and edit a product
1. Your _Author_-field should now be visible among the _General_-fields, if it is not visible make sure that you have the base product selected in the variant drop down, the base product is always the top item in the list.
1. Edit the property and select the author page you created in the [_Author page_-task](../Author%20page) earlier.
