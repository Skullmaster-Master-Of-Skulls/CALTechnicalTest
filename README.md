# Technical Test: Accessible Web Forms Application in C\#

## Objective

Develop a basic web application using ASP.NET Web Forms and Entity Framework that allows users to submit and view registration details. Focus on making the application accessible, adhering to WCAG standards.

## Length of the Test

This is a timed technical test so you must make your last commit and push your project to GitHub within 48 hours of your start time, which will be communicated via email.

## Pre-requisites

You will need the following software installed in your machine to do this test:

- Visual Studio 2022 (recommended)
- .NET Framework 4.8 targeting pack
- SQL Server Developer or SQL Server Express
- SQL Server Management Studio

Please note .NET Framework only runs on Windows, [unless you venture into other methods](https://hub.docker.com/r/microsoft/dotnet-framework).

## Requirements

### Technology Stack

- **Language:** C# (.NET Framework 4.8)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework (**Database-First**)
- **Front-end:** ASP.NET Web Forms

## Test Overview

You are required to create two pages in the web application:

1. A **Registration Form** where users can submit their details.
2. A **Submissions List** page that displays submitted data in a table.

Some starter code has been provided to you in this repository.

### Key Points

- Ensure that your application is accessible and follows **WCAG standards**. Also use WCAG compliant error messages if any implemented.
- Use various form inputs (text fields, dropdowns, radio buttons, checkboxes).
- Data must be stored in an **MS SQL Server** database using **Entity Framework** for database interaction.

## Task Breakdown

### Page 1: Registration Form

Create a registration form with the following fields:

- **First name** (Required; Text input)
- **Last name** (Required; Text input)
- **Email** (Required; Text email input)
- **Preferred Pronouns** (Dropdown list or radio buttons)
- **Level of Study** (Required; Dropdown list or radio buttons)
  - High school graduate
  - Undergraduate
  - Graduate
- **International Student Status** (Required; Yes or No; radio buttons)
- **Disability Information:**
  - **Disability Type** (Required; Dropdown list as a multi-select or checkbox buttons)
    - ADHD
    - Autism
    - Chronic illness
    - Deaf or hard of hearing
    - Learning disability
    - Mental health
    - Neurological
    - Physical or mobility
    - Vision
    - Other
  - **Additional Accessibility Requirements** (multiline text area)
- **Consent** (Required)
  - **Consent Information** (Text paragraph)
  - **Full Name** (Text input)
  - **Confirm Full Name** (Text input)

### Page 2: Submissions List

Create a second page that displays the submitted form data in a table format. Additionally, create a "View" button that when clicked sends the user to the full populated form.

#### Details to Display in the Table

- **First name**
- **Last name**
- **Email**
- **Level of Study**
- **Disability Type**
- **Additional Requirements**

## Additional Requirements

### 1. Entity Framework

- Use Entity Framework to interact with the SQL Server database.
- Define a model that maps to the form submission table.

### 2. Database

You will need to create a simple SQL Server database to store form submissions. It is required you name this database `TechnicalTestDb`, and the data model `TechnicalTestDbEntities`. The table structure below has some suggestions to design the table for form submissions.

- **Table Structure:**
  - **Id** (Primary Key, number)
  - **Name** (varchar)
  - **Email** (varchar)
  - **DisabilityType** (narchar or number with foreign key constraint)
  - **AdditionalAccessibilityRequirements** (varchar)

Feel free to use as many tables as you need in your solution.

## Deliverables

- A link to the fork of this repository with your solution. Ensure the project can be run locally with minimal configuration.
- A SQL script that generates the necessary table(s) in MS SQL Server, or a database backup file.
- A brief document outlining how the candidate ensured WCAG accessibility compliance.

## Bonus Points

- Include unit tests for form validation logic.
- Any accessibility features you use in your implementation.
