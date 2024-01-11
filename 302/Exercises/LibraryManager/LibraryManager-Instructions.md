# Exercise: Finish Library Manager

This exercise will be to finish the library manager, following the pattern we established with the n-tier example. You can find the starter code in the GitHub repository under `Exercises\LibraryManager\Start`. Here are the requirements.

*Note: We want you to practice architecture and design in this exercise, so we will give requirements as if a user wrote them. If you have questions, ask a mentor in the discord channel.*

## Configuration

We want to be able to configure our `ServiceFactory` to use Entity Framework or direct SQL for the database access. To achieve this, modify the configuration interface and classes to expose a new method named `GetDatabaseMode()` that returns an enum with two values: `DatabaseMode.ORM` and `DatabaseMode.DirectSQL`.

Make the necessary modifications to use an `appsettings.json` file to store the mode. When the mode is set, the `ServiceFactory` should inject the appropriate service repositories.

## Create Two Versions of the Repositories

Make two versions for each repository you create: The first should use Entity Framework for database access, and the second should use Dapper or ADO.NET. This will give you practice and allow you to compare and contrast approaches.

You should build the Entity Framework version first and then use Dapper/ADO.NET to 

## Application Layer

All of your business rules (ex, borrower can only check out 3 items) should be checked in the service layer. The UI layer may validate input but not rules.

## Application Functionality

Add the following features to the application, following the pattern of creating interfaces, repositories, and services. We want a 2-level menu with the functionality grouped at the top-level menu. It should look something like this: 

```
Library Manager Main Menu
===============
1. Borrower Management
2. Media Management
3. Checkout Management
4. Quit

Enter choice: 1
```

```
Borrower Management
===================
1. List all Borrowers
2. View a Borrower
3. Edit a Borrower
4. Add a Borrower
5. Delete a Borrower
6. Go Back

Enter Choice: 
```

The "go back" choice should return to the main menu. Here are the rest of the submenus:

```
Media Management
================
1. List Media
2. Add Media
3. Edit Media
4. Archive Media
5. View Archive
6. Most Popular Media Report
7. Go Back
```

```
Checkout Management
===================
1. Checkout
2. Return
3. Checkout Log
4. Go Back
```

Please use your judgment for the workflow of the menus. 

### Borrower Management

* **List all Borrowers** - This is already completed for you as an example.
* **Refactor GetBorrowerById() to View Borrower** - We have learned that borrowers don't remember their ID, so we want to refactor the GetBorrowerById() method to get the borrower information by email instead.
  * When looking up a borrower, also display what media, if any, they have checked out.
* **Edit Borrower** - Look up the borrower by email and allow the user to edit the borrower's record. They should not be able to change their email to something not unique.
* **Add a Borrower** - This is already completed for you as an example.
* **Delete a Borrower** - Look up the borrower by email and ask if the user is sure. If yes, delete the checkout log history and the borrower information in a transaction.

### Media Management

* **List Media** - Prompt the user for the media type and list all of the media, along with its status ("archived or available")
* **Add Media** - Add a new media record. The application should show a list of media types to choose from and allow the user to enter the ID of the media type and the title. 
* **Edit Media** - Prompt the user for a media type and list all the unarchived media for that type. The user should enter the id of the one they want to edit. They may not edit the archived property.
* **Archive Media** - Prompt the user for a media type and list all the unarchived media. The user should enter the id of the one they want to archive. They may not archive media that is currently checked out.
* **View Archive** - Show all of the archived media along with its type. The data should be ordered by type and then title.
* **Most Popular Media** - Display the top 3 media by how many times they have been checked out.

### Checkout Management

* **Checkout Log** - Display all the currently checked-out media (null ReturnDate in the CheckoutLog table). The displayed fields should be the borrower name, email, media title, checkout date, and due date. If the media is overdue, color the due date in yellow.
* **Checkout Media** - First, look up a borrower by email. Then, list all the media that is not checked out or archived. Enter the ID of the media the borrower would like to check out.
  * Do not allow borrowers to check out more than 3 media items.
  * Do not allow borrowers to check out media items if they have any items overdue in the log.
  * The due date should be 7 days after the checkout date.
  * Prompt the user to checkout another item or exit the menu. Repeat the process without the borrower lookup if they want another item.
* **Return Media** - First, look up the borrower by email. Then, list the items they have checked out or display a message if they have none. They should enter the ID of the CheckoutLog that they are returning. Update the ReturnDate to today.

## Unit Testing

Add a unit testing project and create mock classes for your database repositories to test the service layer checkout logic. Do not write unit tests for database logic! Those are integration tests and are something else entirely!

## Advice

This is a larger application, and it is easy to make a mess with the layers. We recommend you approach the application from front to back. This means:

1. Starting with the UI, outline, and design of what you want the console workflows to look like. 
2. Then, list all the service methods you think you will need to accomplish the tasks. Examples of service layer methods include Checkout, Return, etc. 
3. Next, group those methods into services (like the BorrowerService) based on how well the methods relate. Try keeping services related to borrower information in the BorrowerService and those related to the checkout log in a CheckoutService, etc.
4. Figure out what data each service will need to do its job. It is common for services to need multiple repositories. For example, checking out media may require borrower, media, and checkout log information.
5. Create repositories for data access. It is common for repositories to mirror tables. Some database calls will cross multiple tables, like reports. In these cases, put the database method in the repository you think is the "primary" of the query. For example, the most popular media report would likely go in the IMediaRepository.
6. When you decide to work on a feature, try to finish it. Jumping from feature to feature without completing any is demotivating, inefficient, and error-prone.

Remember! Naming things is hard, and organizing things is harder. Do not get analysis paralysis! It's okay to try things and run experiments, and all code can be refactored and reorganized. You will likely change your mind from design to implementation. This is normal!

**It is normal for learners to write this application multiple times or heavily refactor it. There is no one right way to complete it, so run experiments and learn what feels right and what does not.**