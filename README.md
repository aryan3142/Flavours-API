# 👣 **Flavours WEB API**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; PROJECT OverView

Flavours is a leading restaurant chain that operates 50+ restaurants across the country. 
Due to successful business model and solid understanding about consumer needs, the Flavours executive management feels that they can 
increase their business by going online and delivery food to the door steps of the customer. 
They are planning to open an online portal called Flavours through which they want to reach out a larger customer base.

### Project : A WebApi project using .Net Core framework.
#### Project Description :

#### AuthController :
This controller is to generate Json Web token
- Created a private method to generate JWT
- If the user id from source application is -1, then the user role is not set in claims.
- If the user id from source application is 1, then the user role is set as “Admin” in claims.
- If the user id from source application is neither -1 nor 1, then the user role is set as “Customer” in claims.
- Invoke the method that generates the JWT in the GET action method

#### AnonynousUserController :
- This controller is to View all menu items
- Has GET action method, without parameter that invokes the menu item listing method of MenuItems class to get all the menu items
- This controller method allows any request, no authentication and authorization is required

#### AdminController :
- This controller is for Admin person of the application to view and edit menu item
- Has GET action method, without parameter that invokes the menu item listing method of MenuItems class to get all the menu items
- Has PUT action method that takes in the menu item id as a parameter. The menu detail will be sent as data in the body. This is to be extracted and the master data needs to be updated
- This controller method should be authorized ONLY to ‘Admin’ role user

#### CustomerController :
- This controller is for Customer role user of the application to view, add and remove menu item to cart
- Has GET action method, without parameter that invokes the menu item listing method of MenuItems class to get all the menu items. Filters the list for active and the date of launch is not in future
- Has GET action method, with parameter of UserId to get all items for the user in cart along with its total price
- Has POST action method to create a cart item for the user. Hardcode the cartId to 1 for this user
- Has DELETE action method to remove the menu item id that was added to the cart using the cartid 1
- This controller method should be authorized ONLY to ‘Customer’ role users

>## 💻&nbsp; System Requirements
- Git
- Code Editor (Visual Studio Code)

![alt text](<https://github.com/ryan3142/Flavours-API/blob/main/Flavours_API/Screenshots/Flavours2.png>)

![alt text](<https://github.com/ryan3142/Flavours-API/blob/main/Flavours_API/Screenshots/Flavours1.png>)
