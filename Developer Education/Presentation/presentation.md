layout: true
name: section
class: center, top, section-background

<div class="section-background-white">
    <img src="Images/litium_logotyp_rgb.svg" alt="Litium-logo" height="100"/>
</div>

---
template: section

# Developer Education

---
layout: true
name: default

<img src="Images/litium_logotyp_rgb.svg" alt="Litium-logo" height="20"/>

---

# Agenda
--
.left-col[
## Day 1

* About Litium

* Litium Accelerator

* Installation

* Architecture

* Data modelling

* Litium area Websites

* Globalization

* Dependency injection

* Security token
]
--
.right-col[
## Day 2

* Litium areas E-Commerce, PIM, Customers and Media

* Logging

* Events

* Validation

* Web API

* Searching & Batching

* React in Accelerator

* Automated testing

* Certification exam
]

---
template: default
background-image: url(Images/features.png)

---
template: default
background-image: url(Images/architecture-01.png)

???

Product Information System
Order Management System
Content Management System

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

background-image: url(Images/connect.png)

# Litium connect

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
background-image: url(Images/roadmap.png)

# Roadmap



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
background-image: url(Images/accelerator-model.png)

# Litium Accelerator

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

No JQuery

BEM provides a modular structure to your CSS project. Because of its unique naming scheme, we won’t run into conflicts with other CSS names. BEM also provides a relationship between CSS and HTML. Ambiguous names are hard to maintain in the future.

https://medium.com/@dannyhuang_75970/what-is-bem-and-why-you-should-use-it-in-your-project-ab37c6d10b79

---

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
