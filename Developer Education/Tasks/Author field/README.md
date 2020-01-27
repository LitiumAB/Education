# Author field

Our client has to be able to connect books to authors so we need a field to define the link.

To create and connect this field to templates we will use the UI in Litium but it could also be done in code in `Litium.Accelerator.Definitions.Products.ProductsFieldDefinitionSetup`.

1. Open the Control panel in Litium backoffice and select _Products > Fields_ in left menu
1. Click _New_, set **Type**=_Pointer_ and **Id**=_Author_, the field should not have language support
1. Edit the field and set **entity**=_Pages_, optionally also set name for all languages
1. Select _Products > Field templates_ in left menu
1. Edit all field templates where _Type=Product_ and on the fields-tab add your author field into the _General_-fieldgroup 

> **IMPORTANT!** When you did the [_Author page_-task](../Author%20page) earlier you may have modified `DefinitionSetup` so that all templates are re-generated from code on every startup. Since this Author-field is only added in database and not in code it will get removed from the template when the application restarts if automatic re-create is enabled.

Try it out:

1. Select _Products_ in top menu and edit a product
1. The _Author_ field should now be visible among the _General_-fields
1. Edit the property and select the author page you created in the [_Author page_-task](../Author%20page) earlier