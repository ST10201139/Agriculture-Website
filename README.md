# AgriConnectPlatformProject

Welcome to the AgriConnectPlatformProject! This project is designed to provide an efficient and user-friendly platform for managing agricultural data, including farmer profiles and products. This README will guide you through the project, its features, and how to set it up and use it.

## Website Name
AgriCulture 

## Login Details

- **Admin Credentials**: 
  - **Email**: admin@gmail.com
  - **Password**: Password123_
- **User Credentials**: 
  - **Email**: Test@gmail.com
  - **Password**: Test123#
 - **Email**: munsamyliam10@gmail.com
  - **Password**: Test123#
- **Email**: Michael@gmail.com
  - **Password**: Michael123#
## Features

- **User Authentication**: Secure login and registration for users.
- **Role-Based Access Control**: Different functionalities for Super Admin, Employee, and Farmer roles.
- **Farmer Profile Management**: Add, edit, view, and delete farmer profiles.
- **Product Management**: Add, edit, view, and delete products.
- **Responsive Design**: Accessible on various devices with a consistent user experience.

## Technologies Used

- **ASP.NET Core MVC**: For building the web application.
- **Entity Framework Core**: For database operations.
- **Bootstrap**: For responsive design and styling.
- **jQuery**: For client-side scripting.
- **CSS Animations**: For enhanced user experience.


## Navigation Overview
- **Home**: Overview of the platform and its features.
- **Farmers Profiles**: List and manage farmer profiles.
- **Products**: View and manage agricultural products.
- **Add Role**: Manage user roles (Super Admin only).
- **Products Filtering**: Filter products based on various criteria.
- **Logout**: Sign out of the application.

## Home Page Overview
The home page provides a brief overview of the platform, showcasing its main features and functionalities. Users can navigate to different sections such as Farmers Profiles, Products, and Role Management (for Super Admin) from the home page.

## Classes Overview
- **Farmer**: Represents a farmer with attributes such as Name, Address, Email, and PasswordHash.
- **Product**: Represents agricultural products with attributes like Name, Category, and Price.
- **User**: Represents a user with roles and authentication details.
- **Role**: Manages different user roles within the platform.

## Installation
1. Clone the repository:
   ```sh
   git clone https: https://github.com/VCWVL/prog7311---programming-3a---part-2-ST10201139.git
   ```
2. Navigate to the project directory:
   ```sh
   cd AgriConnectPlatformProject
   ```
3. Install the required dependencies:
   ```sh
   dotnet restore
   ```
4. Configure your database connection in `appsettings.json`.
5. Update the database:
   ```sh
   dotnet ef database update
   ```
6. Run the application:
   ```sh
   dotnet run
   ```

## Usage

### Home Page

The home page provides an overview of the application and access to the various functionalities based on the user's role. It includes a navigation bar with links to different sections such as Home, Farmers Profiles, Products, and more.

### Register

To create a new account:

1. Click on the "Register" link in the navigation bar.
2. Fill in the required details including Email, Password, and Confirm Password.
3. Click the "Register" button to create your account.

### Login

To log into your account:

1. Click on the "Login" link in the navigation bar.
2. Enter your registered Email and Password.
3. Click the "Log in" button to access your account.

### Farmer Profile Management

#### Adding a Farmer

1. Navigate to the "Farmers Profiles" section.
2. Click on "Add Farmer".
3. Fill in the farmer's details including Name, Address, and Email.
4. Click "Save" to add the farmer profile.

#### Editing a Farmer

1. Navigate to the "Farmers Profiles" section.
2. Click on the "Edit" button next to the farmer you want to edit.
3. Update the necessary details.
4. Click "Save" to update the farmer profile.

#### Viewing a Farmer

1. Navigate to the "Farmers Profiles" section.
2. Click on the "Details" button next to the farmer you want to view.

#### Deleting a Farmer

1. Navigate to the "Farmers Profiles" section.
2. Click on the "Delete" button next to the farmer you want to delete.
3. Confirm the deletion.

### Product Management

#### Adding a Product

1. Navigate to the "Products" section.
2. Click on "Add Product".
3. Fill in the product details including Name, Description, and Price.
4. Click "Save" to add the product.

#### Editing a Product

1. Navigate to the "Products" section.
2. Click on the "Edit" button next to the product you want to edit.
3. Update the necessary details.
4. Click "Save" to update the product.

#### Viewing a Product

1. Navigate to the "Products" section.
2. Click on the "Details" button next to the product you want to view.

#### Deleting a Product

1. Navigate to the "Products" section.
2. Click on the "Delete" button next to the product you want to delete.
3. Confirm the deletion.

## Recommended System Requirements
- **Operating System**: Windows 10 / macOS / Linux
- **RAM**: 4GB or higher
- **Disk Space**: 2GB free space
- **.NET Core SDK**: Version 3.1 or higher

## Version
- **Current Version**: 1.0.0

## Challenges Faced
- Aligning navigation bar elements to ensure a consistent look across different pages.
- Ensuring responsiveness across various devices and screen sizes.
- Implementing efficient role-based access control to manage user permissions.

## Frequently Asked Questions (FAQs)
### General Questions
1. **How do I reset my password?**
   - Click on the "Forgot Password?" link on the login page and follow the instructions.

2. **Can I add more roles?**
   - Yes, if you are a Super Admin, you can add and manage roles from the "Add Role" page.

3. **How do I filter products?**
   - Navigate to the "Products Filtering" page and use the available filters to search for products.

## Contributors
- [Liam Munsamy]
- [ST10201139@vcconnect.edu.za]
- Feel free to contribute to the project by submitting pull requests or reporting issues.

We welcome contributions to improve AgriConnectPlatformProject. 
To contribute:
1. Fork the repository.
2. Create a new branch.
3. Make your changes.
4. Submit a pull request.


## License
This project is licensed under the MIT License.

## Acknowledgements
1. Israel Quiroz (2023). Scaffold DBContext & Models EASILY in .NET with Entity Framework! [online] YouTube. Available at: https://www.youtube.com/watch?v=dB2V0hUJIR0 [Accessed 28 May 2024].
2. LearnWithMe (2022). #5 BookStore Webbshop | Add simple Authorization | ASP.NET Core MVC Projekt. [online] YouTube. Available at: https://www.youtube.com/watch?v=InsIhr9oX7A&list=PLxbwFov-VyQHOjxTsxMm7PaY3l_8egVpw&index=5 [Accessed 24 May 2024].
3. LearnWithMe (2022). #6 BookStore Webbshop | Adding roles | ASP.NET Core MVC Project. [online] YouTube. Available at: https://youtu.be/gUsRd-E5ETI?si=ZPJDF4LOifaaMpOI [Accessed 1 April. 2024].
4. LearnWithMe (2022). #7 BookStore Webbshop | Edit Roles | ASP.NET Core MVC Project. [online] YouTube. Available at: https://youtu.be/L9cjNC3Xlv0?si=au4ECMtuOrrenrXq [Accessed 1 April. 2024].
5. LearnWithMe (2022c). #8 BookStore Webbshop | Seed users and roles to database | ASP.NET Core MVC Project. [online] YouTube. Available at: https://youtu.be/26VIcXcZlwc?si=LSF9NT2nyy4FEHNS [Accessed 1 April. 2024].
6. LearnWithMe (2022d). #9 BookStore Webbshop | Edit users within a role | ASP.NET Core MVC Project. [online] YouTube. Available at: https://youtu.be/ANxcIPY-0rY?si=sQMrm0nFhp7ezl6l [Accessed 1 April. 2024]
7. mmtuts (2017). 15: How to Insert Images Using HTML and CSS | Learn HTML and CSS | HTML Tutorial | Basics of CSS. YouTube. Available at: https://www.youtube.com/watch?v=_w6N_nplmAw [Accessed 25 May 2024].
8. the IT videos (2016). How to Add CSS Styles in ASP.NET MVC - Part 7. [online] YouTube. Available at: https://www.youtube.com/watch?v=bx6T2TglpH8&t=75s [Accessed 24 May 2024].
9. Web Dev Tutorials (2021). JavaScript - How to Activate a Fade-in Animation for a Div Element on Scroll - Part 2. [online] YouTube. Available at: https://www.youtube.com/watch?v=19jD-DcOBtQ [Accessed 25 May 2024].
10. www.youtube.com. (n.d.). 2 | HOW TO LINK A CSS STYLESHEET USING HTML | 2023 | Learn HTML and CSS Full Course for Beginners. [online] Available at: https://www.youtube.com/watch?v=4OMdzHnys9o [Accessed 24 Apr. 2024].



