layout: true
name: section
class: center, top, section-background

<div>
    <img src="images/litium_logotyp_rgb.svg" alt="Litium-logo" height="100em" />
</div>

---

template: section
# Developer Education
.footer[
Use the arrow-keys to navigate the slides or click the icon in bottom-right corner to open the overview
]

---

layout: true
name: task
class: center, top

<img src="images/devtask.svg" alt="Development task" height="200em" />

# Development task

All tasks are available at [github.com/LitiumAB](https://github.com/LitiumAB/Education/tree/main/Developer%20Education)
<br />(in Education/Developer Education/Tasks)


### Complete the task: 

{{content}}

---

layout: true
name: default
<img src="images/litium_logotyp_rgb.svg" alt="Litium-logo" height="20"/>

---
name: Agenda

.left-col[
## Agenda day 1

* About Litium

* Litium Accelerator

* Installation

* Field framework

* Litium area Websites

* Globalization

* Litium architecture

* Development with dependency injection

* Security token
]
--
.right-col[
## Agenda day 2

* Litium areas E-Commerce and PIM

* Logging

* Events

* Validation

* Extending Litium - Web API and Connect

* Data service

* Accelerator front-end development

* Certification exam
]
---
class: center

# Goals

### Knowledge

> Your ambition is to make you a confident and independent developer, <br/>ready to participate in Litium projects. 

> You will know how to implement most requirements, <br/>and know where to find answers when you don´t.

--
### Certification

> A Litium Developer Certification is a quality mark that build customer trust. 

> Litium Certifications also add business value to partner organizations. 

---
name: Features

background-image: url(images/features.png)

---
name: Architecture stack

<img src="images/architecture-01.png" alt="Architecture" width="100%" />

???

* Product Information System

* Order Management System

* Content Management System

---

# Litium is based on standard technology

* .NET Standard 2.0

* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/index) (Microsoft/Open Source)

* [Newtonsoft JSON](https://www.newtonsoft.com/json) (Open Source)

* [AutoMapper](http://automapper.org/) (Open Source)

* [ASP.NET MVC 5](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started) (Microsoft)

* [ASP.NET WebAPI 5](https://docs.microsoft.com/en-us/aspnet/web-api/overview/) (Microsoft)

* [Angular](https://angular.io/) (Google/Open Source)

???

TODO - Add additional info on usage for each bullet

---
# Roadmap

<img src="images/roadmap.png" alt="Roadmap" width="100%" />


---

template: section

# Litium Accelerator

---

# What is Litium Accelerator?

* A packaged technical solution

    * Speed up starting new projects

    * No need to build from scratch

    * Base for common functionality to start development

* Delivered as source code. 

* Start with current code snapshot and once customized the accelerator will be part of the solution. 

---
# Litium Accelerator

<img src="images/accelerator-model.png" width="100%" />

???

BLL Allows the same business logic to be used in both Web API and in MVC Views

---

# Accelerator technical choices

--

* Design - less is more

--

* Zurb Foundation
    * …for Sites
    * …for E-mails

--
* Style
    * Component based
    * SASS 
    * _Block, Element, Modifier_ methodology (BEM)

--
* JavaScript
    * Component based
    * React
    * Webpack

???

BEM 
* provides a modular structure to your CSS project. 
* Naming scheme to avoid conflicts with other CSS names
* provides a relationship between CSS and HTML

https://medium.com/@dannyhuang_75970/what-is-bem-and-why-you-should-use-it-in-your-project-ab37c6d10b79

---
name: Accelerator MVC & React

.left-col[
# MVC

## For most views and all routing
```
Litium.Accelerator.Mvc/Controllers

Litium.Accelerator.Mvc/Views

Litium.Accelerator/ViewModels
```

]
--
.right-col[
# React + Redux

## For dynamic views

* Compiled with WebPack

* Resources in folder: `Litium.Accelerator.Mvc/Client`

* Web API endpoints in folder: `Litium.Accelerator.Mvc/Controllers/Api`
]

---
template: section

# Installation

---

# Installation

--

## Installation of Litium is done through Visual Studio

* With or without accelerator

--

## Litium is distributed through a private NuGet-feed

* The NuGet-feed is accessed using your [Litium Docs](http://docs.litium.com) user account

* All packages that start with Litium.* are distributed as individual nuget packages

---

# Installation Pre-requisites

System requirements for local development environment are avaliable on [Litium Docs site](https://docs.litium.com/documentation/get-started/system-requirements) 

### Required

* Visual Studio 2019
* Sql Server 2016 or later **(2016 required by Litium hosting!)**
* .NET 4.7.2
* [Litium NuGet feed](https://docs.litium.com/download/litium-nuget-feed) - Requires partner account on docs.litium.com

### Optional (but recommended)

* IIS (verify that .NET development is enabled through _“Turn windows features on/off”_)
* SMTP Server
* sessionState = StateServer
* Elasticsearch
* Redis

???

Change sessionState from InProc to StateServer in Web.config.
`<sessionState mode="StateServer" stateConnectionString="tcpip=127.0.0.1:42424" />`
Run the windows service _ASP.NET State Service_ for this to work

---

# NuGet package for installation

--
.left-col.center[
## Litium.Web.Setup.Complete
<img src="images/nuget-setup-web.png" alt="Nuget web setup" width="150"/>
]

--
.right-col.center[
## Litium.Setup.Complete
<img src="images/nuget-setup.png" alt="Nuget setup" width="150"/>
]

???

Litium.Setup.complete is enough when web is not needed, in:
* Integration kit Windows service 
* Litium Testproject

---
template: task
name: Task: Installation

# Installation

---

template: section

# Installation review

---

# Web.config updates during installation

* Connectionstrings for database and Elasticsearch

* Files folder

    * Temporary files
    
    * Lucene.Net search index files
    
    * Media files
        * In a multi server environment the media files should be shared using the CommonFilesDirectory-setting

* Sessionstate, inProc vs StateServer
    * Use StateServer in local development to verify serialization support

* SMTP

.footer[Read more at https://docs.litium.com/documentation/get-started/web_config]

---

# Useful tools

* [localtest.me](http://readme.localtest.me/)
    
    You can use <mysite>.localtest.me instead of using windows hosts file
Will not work offline

* [ReAttach](https://marketplace.visualstudio.com/items?itemName=ErlandR.ReAttach) 
    
    Visual Studio addon that makes it easy to attach to IIS process for debugging.

* [Baretail](https://www.baremetalsoft.com/baretail/) 

    To keep an eye on the log

* [PaperCut](https://github.com/ChangemakerStudios/Papercut)

    For local email testing

---

template: section

# Demo: Litium Accelerator Front-end

???

Go through the deployed storefront of Litium Accelerator and show briefly what it includes

* Mega menu
* Categories
    * Category filter
* Search
    * Search filter
* Product page
    * Place item in cart
* Checkout
    * Place order with user registration

---

# Login to backoffice

<!-- span fix so that markdown is not formatting the url as clickable link: -->
## Login URL: http<span>://</span>mydomain/litium

Login with **your windows account username and password**

* If you don't belong to the local administrators group in windows you need to [change systemUserGroup in Web.config](https://docs.litium.com/documentation/get-started/web_config) to specify a different group to allow login locally.

* If you are on a domain it should be added to the loginname, otherwise just add a leading backslash, example:

    * With domain: **`MYORG\first.last@myorg.com`**

    * Without domain: **`\first.last@myorg.com`**

???

TODO Add instructions or link on how to change allowed login group

---

background-image: url(images/backoffice-ui.png)

# Administration UI

* Angular

* [ASP.NET WebAPI](https://dotnet.microsoft.com/apps/aspnet/apis)

* [Signalr](https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr)

* Still webforms in <br/> E-commerce (Sales) module

---

# Accelerator – What is deployed?

1. New site in websites area

1. New assortment in PIM

1. Templates and fields for PIM, Websites, Customers and Blocks 

1. Globalization artifacts
    * Channel
    * Country
    * Currency
    * Domain name
    * Market
    * Tax class

---
template: section
# Demo: Litium Backoffice

???
1. Show the dashboard and default widgets
1. Show control panel
    1. Globalization
    1. Editing a field and a template
1. Very briefly show Media
1. View the order created earlier in front-end demo
1. View the person created with the placed order
1. Go through PIM
    1. Base product and variants
    1. Prices 
    1. Stock balances
    1. Publishing to channel
1. Show Websites
    1. Publishing to channel
    1. Blocks


---
template:section
# Data Modelling

---
# Entities

### The following Litium entities support data modelling with the field framework

| PIM | Customers | Websites | Media | Globalization | 
| :-: | :-: | :-: | :-: | :-: |
| Product | Person | Website | Media | Market |
| Category | Group | Page | Folder | Channel |
| | Organization | Block |

???

With Litium 8 additional entities from E-commerce will be added

---

# Field Framework

* Handles all “dynamic” fields (fields defined in the project)

--
* Developers can [create their own field types](https://docs.litium.com/documentation/architecture/field-framework/creating-a-custom-field-type) 
    
    * Field types are per **Installation**

    * Field instances are per **Area**

--
* The field does not need to be added to a Field template to be added to an entity

    * The field template is not the container of fields
    
    * Skip adding a field to a template to make it hidden for editors
    
    * Consider field template as a grouping, and a way to define the display template

--
* Setup is done in the `\Src\Litium.Accelerator\Definitions\`-namespace

???

Non-dynamic fields are for example id, name and articlenumber

In Litium 4.X the field had to be in a fieldtemplate to be used

---

# Field Definition

##  Defined for each Area

* `Litium.WebSites.WebSiteArea`
* `Litium.Products.ProductArea`
* `Litium.Customers.CustomerArea`
* `Litium.Blocks.BlockArea`

Definitions are in `\Src\Litium.Accelerator\Definitions\`

Example:
```C#
new FieldDefinition<CustomerArea>("SocialSecurityNumber", SystemFieldTypeConstants.Text)
{
    CanBeGridColumn = true,
    CanBeGridFilter = true,
    MultiCulture = false,
}
```

---
# Field template

* _Fields_ are added _field groups_

* _Field groups_ are then added to _field templates_

```C#
new PersonFieldTemplate("B2CPersonTemplate")
{
    FieldGroups = new []
    {
        new FieldTemplateFieldGroup()
        {
            Id = "General",
            Collapsed = false,
            Fields =
            {
                SystemFieldDefinitionConstants.FirstName,
                SystemFieldDefinitionConstants.LastName,
                SystemFieldDefinitionConstants.Email,
                SystemFieldDefinitionConstants.Phone,
                "SocialSecurityNumber"
            }
        }
    }
}
```

---
# Pointer field type

* A field type that points to other entities

* Single or multi select

<img src="images/pointer-field-type.png" height="200em" />

```C#
new FieldDefinition<BlockArea>(BlockFieldNameConstants.Link, 
    SystemFieldTypeConstants.Pointer)
{
    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage }
}
```

???

TODO - Replace image with draw.io

---
# Multi field

.left-col[
* A field that is a container for other fields

* The only field that can be used as array
]

.right-col.right[<img class="right-col" src="images/multifield-slide.png" />]

.full-col[
```C#
new FieldDefinition<BlockArea>(BlockFieldNameConstants.Banners, 
    SystemFieldTypeConstants.MultiField)
{
    Option = new MultiFieldOption { 
        IsArray = true, 
        Fields = new List<string>() { 
            BlockFieldNameConstants.BlockImagePointer, 
            BlockFieldNameConstants.LinkText,
            BlockFieldNameConstants.LinkToPage
        } 
    }
}
```
]

???

TODO - replace image with draw.io

---

# Entity Model

* Each entity has its own “entity service”

* Use the service to get, create, update and delete entities

```C#
public abstract class ChannelService : IEntityService<Channel>, 
    IEntityAllService<Channel>
{
    protected ChannelService();

    public abstract void Create([NotNull] Channel channel);

    public abstract void Delete([NotNull] Channel channel);

    public abstract Channel Get(Guid systemId);
    public abstract Channel Get([NotNull] string id);
    public abstract IEnumerable<Channel> Get([NotNull] IEnumerable<Guid> systemIds);
    public abstract IEnumerable<Channel> GetAll();

    public abstract void Update([NotNull] Channel channel);
}
```

---
# Entity model - Updating an entity

1. Create an updatable copy by calling `MakeWritableClone()` on the entity _(objects are read only because cached entities should be non modifiable)_

1. Update the clone and call the update method of the respective entity service

    ```C#
    person = person.MakeWritableClone();

    person.LoginCredential.NewPassword = newPassword;

    _personService.Update(person);
    ```

???

Makewriteableclone
* Creates a clone of the object in cache
* All items are read only when fetched
* The writeable object replaces read-only item in cache

---
# Entity model - Relationships between entities

* Domain models relationships

    * “parent entity” – “child entity” (example baseproduct – variant, a variant cannot exist without a baseproduct)

    * “entity” – “entity”

* A parent entity has “Links” to child entities

    * The link has the SystemId of the child entity

    * The link may have additional information related to the relationship

---
# Entity model - Relationships between entities

<img src="drawiodiagrams/countrytotaxclasslink.png" width="60%" />

```C#
var link = new CountryToTaxClassLink(taxClass.SystemId);
link.VatRate = vatRate; // The link can have additional information related to the relationship

country.TaxClassLinks.Add(link);
_countryService.Update((Country)country);
```

### A TaxClass can exist on its own, but CountryToTaxClassLink needs a Country to exist

Implication: TaxClass has its own TaxClassService, but there is no _CountryToTaxClassLinkService_

???

* A country does not have a tax class object

* Entities are connected with a link-object that can have its own data

* Similar to a connecting-table in SQL Server

---

# Automapper
A convention-based object-object mapper.

### What is AutoMapper?

> “Object-object mapping works by transforming an input object of one type into an output object of a different type.”

### Why use AutoMapper?

> "Mapping code is boring. Testing mapping code is even more boring. AutoMapper provides simple configuration of types, as well as simple testing of mappings."

http://docs.automapper.org/en/stable/Getting-started.html

---

# Automapper

### Register
```C#
cfg.CreateMap<PageModel, ArticleViewModel>()
    .ForMember(x => x.Title, m => m.MapFromField(PageFieldNameConstants.Title))
    .ForMember(x => x.Text, m => m.MapFromField(PageFieldNameConstants.Text))
    .ForMember(x => x.Image, m => m.MapFrom<ImageModelResolver>());
```

### Use
```C#
var articleViewModel = pageModel.MapTo<ArticleViewModel>();
```

### Learn more
http://docs.automapper.org/

---
template:section
# Area: Websites

---

# Blocks

* Has data modelling

* Rendered inside a BlockContainer of a page

* Allow editors to easily change the page structure without developer involvement

* A Block can be Global or Local

    * **Local:** a page has its own instance of a block

    * **Global:** the block has a reference to a single global instance that can be used on multiple pages
    
---

# Websites domain model

* Pages can be “active” in different channels
* A `DraftPage` is the working copy of a Page (a page can only have a single `DraftPage`)

<img src="drawiodiagrams/websites-domain-model.png" width="70%" />

???

TODO - Convert image to draw.io

TODO - Info om WebsiteTextContainer

---
template: task
name: Task: Author page
# Author page

---
template:section
# Area: Globalization

---

# Litium.Globalization

### Entities that are common across areas

* DomainName

* TaxClass

* Language

* Currency

* Country

* Channel (has field framework)

* Market (has field framework)

---

# Market

* Programmatically a market is a group of channels

* Supports data modelling (has the field framework)

* **Products** are sold in a **market** through different **channels**

<img src="drawiodiagrams/market-domain-model.png" width="50%" />

---
# Channel

* Has domain names

* Belongs to a market

* May have a website

* Languages

    * Website language

    * Products language

* Defined for a list of countries

* Supports data modelling

---
# Channel

<img src="images/channel-domain-model.png" width="85%" />

???

TODO - Replace image with draw.io

---
# Country & Tax class

* Products are defined with a Tax class

* The VAT percentage for each Tax class is defined on Country

    * All products with the same tax class has the same VAT percentage

<img src="drawiodiagrams/countrytotaxclasslink.png" width="70%" />

???

TODO - Replace image with draw.io

---
template: section
# Architecture

---
name: Arcitecture


<img src="images/architecture-03.png" width="85%" />

---

# Component model

* Domain entities and their service contracts have the same namespace (example: `Variant` and `VariantService` are both in the `Litium.Products` namespace)

--

* Litium separates contracts (interfaces and abstract classes) and implementations in different assemblies

    * Contract assembly examples
        * `Litium.Abstractions`
        * `Litium.Web.Abstractions`
    * Implementation assembly examples
        * `Litium.Application`
        * `Litium.Infrastructure.MicrosoftServiceBus`

--

* Litium implementations also have a `Impl`-suffix and are decorated as fallback, example:
    ```C#
    [Service(FallbackService = true)]
    public class PriceCalculatorImpl : IPriceCalculator
    ``` 

---

# Service model

* Litium contracts (Services)
    * Artifacts that have “methods” or “operations”

* Interfaces
    * Implement an interface to extend the functionality
    * Or change default functionality by extending default implementation using the [service decorator pattern](https://docs.litium.com/documentation/architecture/dependency-injection/service-decorator)
    * Example: IPriceCalculator

* Abstract Classes
    * Declare service definitions that implementation projects are **not expected to change** 
    * Example: BaseProductService

---
# Redis

> _"An open source, in-memory data structure store, used as a database, cache and message broker"_

--

### Redis is used in Litium for:

* Distributed Cache

* Concurrency

* Service bus

* Session

---

# Redis Distributed Cache

Cache outside the Litium application

* Does not clear when the site restarts

* Faster than database

* Reduces database usage

.footer[An optional development task for distributed cache is avaliable]

???

Redis cache is second line to a short in memory 2-minute cache, for high performance and low memory usage

Improvements in application startup from 3 minutes to 30 seconds

---

# Concurrency

* Pessimistic locking – prevent edits when an entity is being edited
* Optimistic locking – allow edit but check before save if the item has been edited since it was read

--

## Concurrency in Litium

* Optimistic concurrency is available **only in Ecommerce area**

* No other areas have concurrency checks!

* It is possible to enforce pessimistic concurrency with DistributedLock:
    ```C#
    using (_distributedLockService.AcquireLock(key, TimeSpan.FromSeconds(10)))
    {
        // Work with the locked entity
        
        // Tip: the Redis-task has a subtask for working with distributed lock
    }
    ```

.footer[An optional development task for distributed lock is avaliable]

???

### Concurrency
The optimistic concurrency control approach doesn't actually lock anything - instead, it asks User A to remember what the row looked like when he first saw it, and when it's time to update it, the user asks the database to go ahead only if the row still looks like he remembers it. 

https://blogs.msdn.microsoft.com/marcelolr/2010/07/16/optimistic-and-pessimistic-concurrency-a-simple-explanation/


### Distributed lock
With Redis, we use the well proven Redlock algorithm to achieve locking, with very high performance and stability, to make sure that only one order is created for the same payment

---
template: section
# Dependency injection
---
# Dependency injection

### Dependency injection for five-year-olds
> When you go and get things out of the refrigerator for yourself, you can cause problems. You might leave the door open, you might get something Mommy or Daddy doesn't want you to have. You might even be looking for something we don't even have or which has expired.

> *What you should be doing is stating a need*, "I need something to drink with lunch," and then we will make sure you have something when you sit down to eat.

_John Munsch, 28 October 2009._

From https://en.wikipedia.org/wiki/Dependency_injection

---
# Using dependency injection in Litium

```C#
public class Needy
{
    public Needy(IIceCream iceCream) // I just want any icecream
    {
        iceCream.Serve();
    }
}

// This decorator handles the entire dependency injection registration
[Service(ServiceType = typeof(IIceCream))]
public interface IIceCream
{
    void Serve();
}

// This implementation gets sent to Needy when needed 
public class ChocolateIceCream : IIceCream
{
    public void Serve()
    {
        // Serve some chocolate icecream
    }
}
```
[Read more on Litium Docs](https://docs.litium.com/documentation/architecture/dependency-injection/service-registration)

---
# Dependency injection lifetime

```C#
[Service(ServiceType = typeof(IIceCream), Lifetime = DependencyLifetime.Singleton)]
[RequireServiceImplementation]
public abstract class StockService
{
    // ...
}


```
#### Lifetime
* **Singleton:** Clients will always receive that same instance from the container
* **Scoped:** The same instance is used within the scope
    * The entire web request
    * The execution of a scheduled task
* **Transient:** A new instance of the component will be created each time the service is requested from the container

#### RequireServiceImplementation
* When a implementation is required for the application to run

???

### Risks with DI

* Classes are selected during runtime making it harder to see what code is executing

* Using a scoped or transient service inside a singleton may cause issues with state being stored longer than expected

---
template: task
name: Task: Author service
# Author service

???

# Optional implementation 
The recommended way to implement this is to set the Books-property using automapper. 

It is slightly more complex and therefore not used in task.

In the mapping call a custom valueresolver:
```C#
cfg.CreateMap<PageModel, AuthorViewModel>()
    // ...
    .ForMember(x => x.Books, m => m.MapFrom<BookResolver>());
```
Define valueresolver:
```C#
[UsedImplicitly]
protected class BookResolver : IValueResolver<PageModel, AuthorViewModel, List<string>>
{
    private readonly IAuthorService _authorService;

    public BookResolver(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public List<string> Resolve(PageModel source, AuthorViewModel authorViewModel, List<string> destMember, ResolutionContext context)
    {
        return _authorService.GetBooksByAuthor(source.SystemId);
    }
}
```

---
# Service Decorator

* To change or replace default implementation

    * Usually to inject business logic

    * “Strategy pattern” in software design

* To inject new business logic

    * “Decorator pattern” in software design

* Advantages over “inheritance” (subclass)

    * Dynamically add/replace business logic

    * Reference Litium abstraction namespaces only

    * Extend without knowing which class implements interface

---
template: task
name: Task: Author service decorator
# Author service decorator

---
template: section
# Security token

---
# Security token

* In Litium, permissions are enforced by using “SecurityToken” object

    * `SecurityToken.CurrentSecurityToken` contains the security token for the logged in user

* Current token is automatically “applied” in the “code execution context”

    * Code is always executed using the currently logged in users permissions

    * If not logged in this is anonymous permission

---
# Security token

If we want to create objects in a integration job the running context will lack permissions to modify data:
```C#
category = category.MakeWritableClone();

var categoryToChannelLink = new CategoryToChannelLink(channelId);
category.ChannelLinks.Add(categoryToChannelLink);

_categoryService.Update(category);
```

--
If the current user does not have permission a `Litium.Security.AuthorizationException` is thrown when `Update()` is called

--
To solve this we can temporarily impersonate the SystemUser:
```C#
// Pass optional parameter to ActAsSystem to show a more informative name in audit log:
using(_securityContextService.ActAsSystem("MyIntegrationJob"))
{
    _categoryService.Update(category);
}
```

---
# Security Token – Old API (Ecommerce)

* In the old API the token has to be passed into every API method that requires permission enforcement

* Current SecurityToken can be constructor injected

* Can also be taken from the static SecurityToken.CurrentSecurityToken
 
Example from `Src\Litium.Accelerator\Services\CheckoutServiceImpl.cs`:
```C#
public override void ChangeDeliveryMethod(Guid deliveryMethodId)
{
    var currentOrderCarrier = _requestModelAccessor.RequestModel.Cart.OrderCarrier;
    _moduleECommerce.CheckoutFlow.AddDelivery(
        currentOrderCarrier, 
        deliveryMethodId, 
        new AddressCarrier(), 
        SecurityToken.CurrentSecurityToken);
    _moduleECommerce.Orders.CalculateOrderTotals(
        currentOrderCarrier, 
        SecurityToken.CurrentSecurityToken);
}
```

---
template: section
# Area: Ecommerce

---
# The shopping cart

.left-col[
* Cart object is kept in Session

* Can be persisted

    * In DB – need to be logged in

    * Per machine – using cookies

* Only article number and quantity is stored, other information might change, e.g. Prices
]
.right-col[<img src="images/ecom-cart.png" width="100%" class="img-border" />]
.footer[Read more: https://docs.litium.com/documentation/litium-documentation/sales/shopping_cart]

---
# Create order

<img src="images/ecom-create-order.png" width="90%" />

.footer[Image from https://docs.litium.com/documentation/litium-documentation/sales/checkout_flow<br/>
Read more: https://docs.litium.com/documentation/litium-documentation/sales/how-to-place-an-order]

???

TODO - Replace image with draw.io

---
name: Create order - detailed

<img src="images/ecom-create-order-detail.png" width="70%" />

.footer[Read more: https://docs.litium.com/documentation/litium-documentation/sales/how-to-place-an-order]

---
# Plugins in Ecommerce

<img src="images/ecom-plugins.png" width="70%" />

???

ECommerce plugins allow extending the ECommerce functionality and customizing its behaviour.

It is possible to have multiple implementations of plugins and create custom selectors to decide which plugin to use, see IPluginSelector link in slide for more information.

Options to extend/replace a plugin

1. Replace implementation by creating class that implements interface, LitiumStudio will automatically detect your custom implementation and will use it instead of the default implementation.

2. Write your classes by extending the classes provided by the default implementation. Usually the default implementation provide virtual methods to allow this type of extention.

https://docs.litium.com/documentation/developer-guides/sales/architecture-design
https://docs.litium.com/documentation/developer-guides/sales/architecture-design/ecommercepluginarchitecture/ipluginselector-interface-and-plugin


---
# Checkoutflow info

* Checkout flow is the process of buying the items in the shopping cart

* CheckoutFlowInfo Keeps additional information required during checkout that is not saved in the Order

* Example: Used to pass CancelUrl and ReturnUrl payment providers

---
# Payment providers - collect payment

<img src="images/ecom-payment-provider.png" width="70%" />

```XML
<pluginSettingx traceMode="true">
```

.footer[https://docs.litium.com/documentation/developer-guides/sales/payment-providers<br/>
https://docs.litium.com/documentation/add-ons/payments/overview]

???

Payment provider configurations has tracemode-setting to activate logging

---

# Pricing rules

* Pricing rules defines how price of a product is determined and how the order grand total and taxes are calculated

* The pricing rules plugin use info from order price fields to do calculations

* Plugins can be replaced by custom code

<img src="images/ecom-pricing-rules.png" width="100%" />

.footer[https://docs.litium.com/documentation/litium-documentation/sales/pricing_rules_1<br/>
https://docs.litium.com/documentation/litium-documentation/sales/pricing_rules_1/changing-pricing-rules]

---
# State transitions

.left-col[
<img src="images/ecom-order-states.png" height="65%" />    
]
.right-col[
* OrderState, DeliveryState and Paymentstate flows execute together

* PaymentState inside Litium, not possible to modify

* States can only be changed according to predefined conditions

* The implementation project can add/remove/modify states and the various conditions and transitions among them
]


.footer[https://docs.litium.com/documentation/developer-guides/sales/working_with_state_transitions<br/>
https://docs.litium.com/documentation/developer-guides/sales/architecture-design/state_transition_plugin_1]

???

States
* Set conditions that need to be fulfilled to enter or exit a state 
    * Show OrderStateBuilder.TransitionsFromInitState 287 Init to Cancelled
    * Show DeliveryStateBuilder (95) from Init to Processing: You cannot start delivery if order is not confirmed
* Entry-/Exit actions
    * OrderStateBuilder (34), status confirmed 
    * States should not be changed in entry-/exit actions!!
* Related states, such as payment pushing order forward, is setup in StateTransitionBuilder


Demo in backoffice:
* Place order
* Show Order/Delivery/Payment in BO
* Change deliverystate in backoffice from Init to Processing
    * Order will go from confirmed into processing
* Change deliverystatus from processing to delivered
    * Order will go to completed
    * Payment will go to paid

* Show how this is set up in code
    * Show code in StateTransitionBuilder

---
# State transitions – In Accelerator

.left-col[
<img src="images/ecom-order-states-accelerator.png" width="80%" />    
]
.right-col[
All the transitions are done automatically based on Delivery state and Payment state transitions
]

.footer[https://docs.litium.com/documentation/litium-accelerators/develop/state-transitions/order-states-in-accelerators]

---
# Campaigns

* A campaign has a single action and zero to many conditions
    * All campaign conditions need to be met for the action to be applied
* It is possible to develop both custom campaign actions & custom campaign conditions

.footer[https://docs.litium.com/documentation/developer-guides/sales/campaigns]

---
template: section
# PIM
## Product Information Management

---
# Product structure

.left-col[
<img src="drawiodiagrams/pim-product-1.png" height="40%" />
]

--

.right-col[
<img src="drawiodiagrams/pim-product-2.png" height="40%" />
]

???

* The baseproduct is a container
* The variant is the buyable entity of the product
* Mention that price and stock is only set on the Variant
* Articlenumber is mandatory field on both base product and variant
* Fieldtemplates can have fields on both baseproduct and variant level

---
# PIM Data Model

<img src="drawiodiagrams/pim-data-model.png" width="70%" />


???

If multiple categories are connected then other categories have canonical to main category to avoid seo issues with duplicate content

A website can only be connected to one assortment, only products in that assortment will work with correct url’s

Show lists in Backoffice!
* A list can be used and published on a website
* A dynamic list is a static list with an event based engine that adds/removes items from the list 

---
# Relations between products and categories

<img src="drawiodiagrams/pim-relations.png" width="40%" />

## Relationship types
* Directional “Accessories”
* Bi-directional “Similar products”

---
# Display templates

* Possible to define different templates per website

* Products can use either base product url or variant url

    * Defined on the display template

    * When variant url is used it is possible to manage how variants are grouped in listings

    * In Control _Panel > Accelerator_ the default implementation has a UI to select grouping field

---
# Common PIM extension points

### `IPriceCalculator`

Get price from ERP in complex B2B scenarios

### `IStockStatusCalculator`

Adjust so that package product inventory is the sum of its parts

---
template: task
name: Task: Pricing rules
# Pricing rules

---
template: section

# Logging

---
# Audit log

* Logging of updates in PIM

* Logging when users with access to customer or order area login to the system

    * This log has no UI
    * Available in _Auditing_-schema in DB

<img src="images/audit-log.png" width="100%" class="img-border" />

---
# Error handling

## All errors should be logged by the developer.
* Wrap with `try/catch` 

* Never `catch` without logging the exception

## Constructor inject `ILogger<Type>`
* In static classes (like extension methods) use `typeof(MyClass).Log()`

* Avoid using `this.Log()` extension method (harder to test)


---
# Event log

* Managed in NLog.config

--

* Log to database, access in backoffice
    <img src="images/event-log.png" width="100%" class="img-border" />

--

* Log to file
    <img src="images/event-log-file.png" width="100%" class="img-border" />

---
template: section
# Events

---
# Event system

* All events are handled by `Litium.Events.EventBroker` (publish/subscribe)

    * To write your own events, or to listen to and trigger existing events

* All events are triggered by the application

* All events are local
    * i.e. in a multi server environment, update of an entity raises an event **only on current server**.

    * Adjust scope when publishing event to also send it to all servers via service bus

* You may modify the database (at own risk!) but this bypasses all change events

.footer[https://docs.litium.com/documentation/architecture/events-handling]

???

Events are used to sync cache and search index on every application/server

---
class: scrollable

# Creating a custom event

### Step 1: Declare the event class, typed with the object we need to pass:
```C#
public class MyEvent : EventArgs<Currency>, IMessage
{
    public MyEvent(Currency item) : base(item)
    {

    }
}
```

### Step 2: Publish the event:
```C#
public class MyEventPublisher
{
    private readonly EventBroker _eventBroker;

    public MyEventPublisher(EventBroker eventBroker)
    {
        _eventBroker = eventBroker;
    }

    public void SendEvent()
    {
        _eventBroker.Publish(new MyEvent(new Currency("SEK")));
    }
}
```

### Step 3: Subscribe to the event and act when it occurs:
```C#
// The autostart decorator on the creates an instance so that our subscription
// gets registered when the application starts
[Litium.Runtime.Autostart]
public class MyEventSubscriber : IDisposable
{
    private readonly ISubscription<MyEvent> _subscription;

    public MyEventSubscriber(EventBroker eventBroker)
    {
        // Register a subscription on the EventBroker
        _subscription = eventBroker.Subscribe<MyEvent>(ev =>
        {
            // This code will execute every time MyEvent is published
            // Get the currencyobject from the event instance and act on the data
            var currency = ev.Item;
        });
    }

    public void Dispose()
    {
        // Remove the event from the event broker
        _subscription.Dispose();
    }
}
```
<br/>
<br/>
<br/>

???

* Interface `IMessage` need to be implemented by all classes that should be send as an event on the Litium.Events.EventBroker

* Overload on `_eventBroker.Publish()` that accepts scope parameter to possibly send to all applications


---
# Service bus

* Used to send messages between applications. 

* The queue is outside the application

    * Processed even if application restarts
    * Free up resources by running queue in the background

* Two different types of message queues

    * Queue – Same message queue for all applications
    * Topic – Unique queue for each application

* Required in all multi-server solutions 

* Note: Servers are updated **“Near real time”**

.footer[https://docs.litium.com/documentation/architecture/service-bus]

???

* Local on application if no Service Bus is configured, can be used to develop locally without setting up service bus

* Application = A running Litium instance connected to the same database

* Example Queue: Update smart list content (in db-table) - only one server has to do the job

* Example Topic: Remove from cache (must be done on all servers)

* By default the queue is stored in the bus for approx 1 day

* Supported:
    * Redis
    * Windows service bus on a server 
    * Azure service bus

* Tested:
    * Service bus in Microsoft Azure – 150 items/sec​
    * Redis in Microsoft Azure – 400 items/sec​
    * Redis in Litium Cloud – 5000 items/sec​

---
template: section
# Validation

---
# Business rules validation

```C#
public class ValidationExample : ValidationRuleBase<Currency>
{
    public override ValidationResult Validate(Currency entity, 
        ValidationMode validationMode, CultureInfo culture)
    {
        var result = new ValidationResult();
        if(entity.TextFormat != "C0")
        {
            result.AddError("TextFormat", "Need to be C0")
        }
        return result;
    }
}
```

* Inheriting `ValidationRuleBase` instead of `IValidationRule` gives a typed entity

* Inheriting `ValidationRuleBase` is enough to register the validation to be executed on every entity modification

???

The first parameter in AddError defines where the message is shown.
One validation can add multiple messages, example
```C#
result.AddError("AuthorField", "A author field error message");
result.AddError("Brand", "A brand field error message");
result.AddError("*", "A global error message shown at the top of the edit-page");
```


---
template: task
name: Task: Author field
# Author field

---
template: task
name: Task: Validation
# Validation

---
template: section
# Extending Litium

---
# Litium core APIs

<img src="images/core-apis-2.png" width="100%" />

???

* Covers all entities
* Litium .NET API
* Litium Admin Web API
* Event subscription with Webhooks

---

background-image: url(images/connect.png)

# Litium connect

---

# Litium connect

.left-col[
### What is it?

* Stand alone applications

* High level Web API interface

* Subscribe to Web hooks

* Guaranteed delivery

* Security with OAuth and Litium service accounts

* High performance
]

--

.right-col[
### Benefits

* Integrations as applications

* Deploy and scale without restarting Litium

* Litium version agnostic, example:

| Litium platform | ERP API | Channels API | Payments API |
| :-: | :-: | :-: | :-: |
| 7.4 | 1.0 | - | - |
| 7.6 | 2.0 | - | - |
| 7.7 | 2.0 | 1.0 | - |
| 8.0 | 2.0 | 1.0 | 1.0 |


]


???

Web hooks = Example, leave phonenumber to be called back in phone queue

Guaranteed delivery = Litium tries to deliver the message a few times before giving up 

---

# Web API

* Useful for

    * RESTful applications

    * Integration when server is communicating with other servers.

* Service Accounts – Access services without access to Litium Backend

* **OnlyJwtAuthorization** - attribute to restrict API endpoint to only use JSON Web Token (JWT)

* **OnlyServiceAccountAuthorization** – attribute to restrict API endpoint to only allow Service Accounts

.footer[Read more: https://docs.litium.com/documentation/architecture/web-api]

---
# Swagger API documentation

* Available at http://domain/litium/swagger (permission required)

* Covers Accelerator Web API, Litium Connect and Admin Web API

<img src="images/swagger.png" width="75%" />

---
# AddOns

## Following are some of the most frequently used AddOns

--

### Product Media Mapper 
To connect images and files to products automatically

--

### Payment providers 
Klarna, Dibs, PayEx, Adyen, PayPal, Nets, Handelsbanken Ecster, Skrill

--

### Integration kit
Starting platform to develop file based integrations towards Litium

---
# Headless API AddOn

* Platform to build use Litium E-Commerce via Web API 

* In particular to use external CMS systems with Litium as the Ecommerce processing and PIM data engine

* Self documenting with [OpenApi/Swagger](https://docs.litium.com/documentation/add-ons/integration/litium-headless-api/configure/docs)

.footer[https://docs.litium.com/documentation/add-ons/integration/litium-headless-api]

---
# Distribution – Add-Ons/Accelerator

### Compiled Add-Ons (e.g. payment provider addOns)

Install via NuGet packages

### Accelerator and source code Add-Ons (e.g. Integration Kit)

Download from https://docs.litium.com 

--
### The Litium platform and licensed Add-Ons (e.g. Accelerator and Integration Kit) can not be reused or shared after download

---
template: task
name: Task: Web API

# Web API

---
template: section
# Searching & Batching

---
# Litium Search

Litium Search is built on Elasticsearch with additional plugins and administration interface

* One distributed search engine for all web servers

* Part of Litium Accelerator

* Litium Backoffice (except E-Commerce) searches directly against the database

    * Litium E-Commerce is using the Lucene.NET search enginge both in backoffice and Accelerator frontend

.footer[Read more: https://docs.litium.com/documentation/architecture/search]

???

It is possible to fine tune how the indexing of a item is made, and what fields to include​

The configuration options is not only for indexing, you also get full flexibility when searching, you can improve the importance of different fields and adjust how search result should be presented to match what the visitor expect.

TODO - Add task on query with the above options for boost and presentation

---
# Litium Search

* Litium Accelerator includes indices for pages, categories and products

* Additional indices [can be added](https://docs.litium.com/documentation/architecture/search/elasticsearch/how-to-add-a-search-index) if needed

<img src="images/litium-search-indices.png" width="90%" />

---
# Litium Search

* Add an manage synonyms in Litium Backoffice

<img src="images/litium-search-synonyms.png" width="90%" />

---
# DataService - Batching data

```C#
Litium.Data.DataService.CreateBatch
```

### Create, Delete and Update multiple domain objects in a single transaction

* If one operation fails, the whole batch is rolled back. 

* All entities in a single batch are logged together in logging for auditing

* Bigger batches **might be slower** than small batches

    * Developers need to find the balance for batch size in the project

        _(Example, sync 5 items at a time might be optimal and 10 is actually slower)_

.footer[[Optional development task is avaliable for Data service](https://github.com/LitiumAB/Education/tree/main/Developer%20Education/Tasks/Data%20service)]

???

Example, create a baseproduct and all variants in a single transaction to avoid creating incomplete products

---
# DataService - Batching example

### `Litium.Data.DataService.CreateBatch`

```C#
var baseProduct2Delete = _baseProductService.Get("123-456");
var fieldTemplateSystemId = baseProduct2Delete.FieldTemplateSystemId;

var baseProduct = new BaseProduct("777-d1", fieldTemplateSystemId) 
{ 
    SystemId = Guid.NewGuid() 
};
var variant = new Variant("445-87", baseProduct.SystemId);

using (var db = _dataService.CreateBatch())
{
    db.Delete(baseProduct2Delete);

    db.Create(baseProduct);
    db.Create(variant); // If the variant fails the baseproduct is not created

    db.Commit();
}
```
.footer[See the full code sample on https://docs.litium.com/documentation/architecture/data-service]

---
# DataService - Querying data

```C#
Litium.Data.DataService.CreateQuery
```

## Querying direct towards database

Do not use towards public site, without implementing own [caching](https://docs.litium.com/documentation/architecture/distributed-caching)!

.footer[[Optional development task is avaliable for Data service](https://github.com/LitiumAB/Education/tree/main/Developer%20Education/Tasks/Data%20service)]

???

Caching example is done in the Redis development task

---
# DataService - Querying example

### `Litium.Data.DataService.CreateQuery`

```C#
using (var query = _dataService.CreateQuery<BaseProduct>(opt => opt.IncludeVariants()))
{
    var q = query.Filter(filter => filter
        .Bool(boolFilter => boolFilter
            .Must(boolFilterMust => boolFilterMust
                .Field("MyField", "eq", "MyValue")
                .Field("MyField2", "neq", "MyValue"))
            .MustNot(boolFilterMustNot => boolFilterMustNot
                .Id("neq", "my_new_articlenumber"))))
        .Sort(sorting => sorting
            .Field("MyField3", CultureInfo.CurrentCulture, SortDirection.Descending));

    int totalRecords = q.Count();
    List<BaseProduct> result = q
        .Skip(25)
        .Take(20)
        .ToList();
}
```
.footer[See the full code sample on https://docs.litium.com/documentation/architecture/data-service]

???

The querylanguage is custom but inspired by the structure in Elastic search

---
template: section
# Accelerator front-end development

---
# Accelerator front-end code structure

* Component based

* ES6

* React + Redux

* [BEM](http://getbem.com/introduction/) (Block, Element, Modifier methodology) for CSS

    * Modular: Styling independent of elements type and nesting

    * Encourage reusing blocks

    * Avoids multilevel nesting and minimal CSS selectors

* Foundation Zurb

* Foundation Email

---
class: scrollable

# React components - Rendering the Buy button

1. Buy button is added on the server in the MVC view `_VariantItem.cshtml`:
    ```Razor
    @Html.BuyButton(model => model.ProductItem, isBuyButton: true) 
    ```
    The HTML-helper used from `ProductItemViewModelHtmlExtensions` renders a HTML-tag:
    ```HTML
    <buy-button ...
    ```
1. In `index.js` on the client Litium identifies HTML-tags that are placeholders (for example buy-button and minicart) and replaces these tags with Redux components. The same [Redux store](https://redux.js.org/basics/store/) is injected in every component.

    ```JavaScript
    const bootstrapComponents = () => {
        if (document.getElementById('miniCart')) {
            ReactDOM.render(
                <Provider store={store}>
                    <MiniCartContainer />
                </Provider>,
                document.getElementById('miniCart')
            );
        }
        ...
    ```
1. In `BuyButton.container.js` the button is rendered, the click-event of the button triggers the add event of `Cart.action.js`:
    ```JavaScript
    import { add as addToCart } from '../Actions/Cart.action';
    ```
    
    ```JavaScript
    render() {
        return (
            <span ref={this.buttonRef}>
                <BuyButton {...this.props} 
                    onClick={(articleNumber, quantityFieldId) => this.props.addToCart(
                        this.buttonRef.current, articleNumber, quantityFieldId)} />
            </span>
        );
    }
    ```

.small[Read more: https://docs.litium.com/documentation/litium-accelerators/develop/buy-button]

<br/>
<br/>
<br/>

---
class: scrollable

# React components - Clicking the Buy button

1. When a buybutton is clicked the `Add()`-method in `Cart.action.js` trigger a POST to the server:
    ```JavaScript
    return post('/api/cart/add', { articleNumber, quantity: parseInt(quantity) })
        .then(response => response.json())
        .then(cart => {
            dispatch(receive(cart));
    ```
1. After returning from the server controller `Litium.Accelerator.Mvc.Controllers.Api.CartController.Add()` the `receive`-action is triggered

1. In `Cart.reducer.js` the `CART_RECEIVE`-action updates state with fresh cart data from the server
    ```JavaScript
    switch (action.type) {
        case CART_RECEIVE:
        case CART_SHOW_INFO:
            return {
                ...state,
                ...action.payload,
            };
        default:
            return state;
    }
    ```
    `action.payload` contains the cart passed in `dispatch(receive(cart))`

1. All components that share state gets updated, for example the MiniCart-component

.small[Read more: https://docs.litium.com/documentation/litium-accelerators/develop/buy-button]

<br/>
<br/>

---
class: scrollable

# State on the client

To give the stateless Web API controllers access to the current Litium state (current page/channel/product) that data needs to be passed in every request.

1. In the shared view `\Shared\Framework\ClientContext.cshtml` the global object **`window.__litium.requestContext`** is written to the rendered page:

    <img src="images/client-state-console.png" width="95%" class="img-border" />

1. When the client then sends a ajax-request to the server the call is done using `Services/http.js` that attaches `window.__litium.requestContext` to the request

    ```JavaScript
    headers: {
        'litium-request-context': JSON.stringify(window.__litium.requestContext),
    }
    ```

1. `RequestModelHandler` on the server parses the object in the request and store it in `RequestModelAccessor`

    ```C#
    var siteSettingViewModel = request.Headers.GetSiteSettingViewModel();
    ```

1. A API Controller (for example `CheckoutController`) can then inject and use `RequestModelAccessor` to get state for the request
    ```C#
    public CheckoutController(RequestModelAccessor requestModelAccessor ...
    {
        ...
    ```

<br/>
<br/>
<br/>

---
template: section
# Upgrading

---
# Upgrading

* As with installation, upgrading the Litium platform is done through Visual Studio nuget update

    * Upgrading the Litium database is done with a SQL-script

        * `packages\Litium.Setup.Core\tools\UpgradeToLatest.sql`

        * Can be executed with Package Manager Console in Visual Studio
            ```console
            Update-LitiumDatabase
            ```

        * No way back, backup before running the script

* Upgrading Litium Accelerator is manual
    * New release package can be used

---
template: section
# Next step

---
# Resouces

| What<br/><br/> | Where |
|:--|:--|
|Documentation, release notes and downloads<br/><br/>|https://docs.litium.com/<br/><br/>|
|Solution help, License or technical questions<br/><br/>|https://docs.litium.com/support<br/><br/>|
|Technical failures, bug reports<br/><br/>|https://docs.litium.com/support/bugs/report-a-bug<br/><br/>|
|Litium slack<br/><br/>|https://docs.litium.com/community<br/><br/>|
|General questions and discussions<br/><br/>|https://forum.litium.com<br/><br/>|
|Feature ideas and requests<br/><br/>|https://ideas.litium.com<br/><br/>|

---
# License

* A license file is required to access Litium from a machine other than localhost

    * The initial installation uses a demo license which only allows requests from the local computer.

* The license must cover all environments (test/prod/stage) that customers have access to

* Request a License file from https://docs.litium.com/support/request-license

---
template: section
# Thank You!
