# Calculator

Project consists of 3 parts:
1. Calculator
2. CalculatorTests
3. CalculatorWebApp (inc. REST API)

## Calculator
This consists of the calculator interface and class implementation. The implementation includes some checks to see if the result of the method falls outside of integer bounds and if so returns an ArithmeticException. This is due to the potential issue of an overflow with 2 integer inputs and an integer output.

## CalculatorTests
This is the MSTest test project for the Calculator class. Each Calculator method has 2 test methods, one where a valid result is expected (_ReturnsResult) and one where the result would overflow and cause an ArithmeticException (_ReturnsException). 

Each method is also decorated with DataRows to allow for different input values and expected outcomes for a given test result.

## CalculatorWebApp
This consists of an Angular SPA and a C# REST API Controller. 

### REST API
The REST API would likely want to be a separate CalculatorService project, but for ease of calling and avoiding potential XSS issues it's part of the web app. The API methods call the relevant calculator method, wrapped in a try/catch, returning the result or a HTTP BadRequest and suitable message on an ArithmeticException from the calculator

### Angular App
The Angular application is generated from a VS2022 template, with the Calculator component creating a Dialog via Angular Material. As part of creating the Dialog the component will set the dialog panel CSS class (togglable using the button on the parent page). The Dialog will call the REST API as appropriate and display the result. In the event of an error, it will log the error to the console and display an alert informing the user of the error, this would ideally be a handled in a more user acceptable/friendly manner.

Dialog code based on the documentation and code examples for Angular material (v14): https://v14.material.angular.io/components/dialog/overview.

### Styling
Most styling comes from Bootstrap / Angular Material. There are 2 custom CSS Styles present in the Style.CSS used to change the style of the Dialog. The DefaultDialogStyle doesn't have any rules in it, but is present to show where the rules would be placed if styling was desired. The AltDialogStyle has some rules to change the background and text colours. 

In the event of a particular small display the Calculator Dialog is responsive and should change the layout of the buttons to be a single vertical list.

The "deeppurple-amber" style sheet is an Angular Material theme and doesn't contain any custom CSS on my part. 

## Testing
The application has been tested in Firefox, Google Chrome and Edge, as well as various phone/tablet emulators within them. In all cases the display was fine and the calculator worked as expected.
