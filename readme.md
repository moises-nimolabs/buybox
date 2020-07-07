# Buy Box  
## Description  
Virtual implementation of a [Vending Machine](https://en.wikipedia.org/wiki/Vending_machine)

## Product Data
Vending machine contains the following products:  
* Tea (1.30 eur), 10 portions  
* Espresso (1.80 eur), 20 portions  
* Juice (1.80 eur), 20 portions  
* Chicken soup (1.80 eur), 15 portions

## Coin Data  
At the start the vending machine wallet contains the following coins (for exchange):  
* 10 cent, 100 coins  
* 20 cent, 100 coins  
* 50 cent, 100 coins  
* 1 euro, 100 coins  

The customer has an unlimited supply of coins.  
Vending machine should support the following features:  

## Features  
### Accept coins  
Customer should be able to insert coins to the vending machine.  

### Return coins
Customer should be able to take back the inserted coins in case customer decides to
cancel his purchase.  

### Sell a product  
Customer should be able to buy a product:  

### Considerations

* If the product price is less than the deposited amount, Vending machine should show a message “Thank you” and return the difference between the inserted amount and the price using the smallest number of coins possible.  
* If the product price is higher than the amount inserted, Vending machine should show the following: 
1. A message “Insufficient amount”  
2. The amount 
3. The type of coins returned should be shown by the UI   
* `This wasn't clear about what should be returned, in this case I decided to return the inserted tokens, since it's the choice of the user the types of tokens he wants to include in the machine.`

## How To  
### Requirements  
1. Docker for Windows, Docker Toolbox or Docker for Mac  
2. .Net Core SDK 3.1  
3. Angular-CLI installed globally  

Database and web servers are running on docker to avoid over-installation of uneeded components on your machine.  

### Apply Environment Specific Settings  
Make sure you have `Docker Toolbox` or `Docker for Windows` installed. If you use Windows, make sure you use `Linux Containers`.  
Update the application settings to match the Docker IP address:
1 `./BuyBox/src/environments/environment.ts`  
   Change the setting: `apiEndpoint`  
2 `./BuyBox.Api/appsettings.json`  
   Change the setting: `ConnectionStrings:BuyBoxDbContext`  
By default they are pointing to `Docker Toolbox` virtual machine on the address `192.168.99.101`.  

### Build the Sol

* Using any shell tools, `cd` to the project root folder:  
* Run `yarn`  
* Cd to the folder `./BuyBox` 
* Run `yarn`  
* `cd` back to the root folder  
* Run the commands in the following order