console.log("This runs when the script loads");

function ourFunction(parameterOne, parameterTwo) {
    console.log("This only runs when the function is called");
    console.log(`${parameterOne} : ${parameterTwo}`)
}

// The global arguments object has details about the parameters for a method call
function unknownParameters() {
    console.log(arguments.length)
    console.table(arguments);
}

// The rest operator allows a function to be defined with an unknown # of parameters
function functionWithRestOperator(...args) {
    console.table(args);
}

// The spread operator breaks an array/object/string into multiple parameters
const nums = [1,2,3,4,5,6,7,8,9,10];

function spreadOpeatorExamples() {
    unknownParameters(...nums);
    unknownParameters(...'Hello');
}

/*
* Anonymous Functions
*/
function doubleTheSum (x, y) {
    return (x + y) * 2;
}

const doubleTheSumAsVariable = function (x, y) {
    return (x + y) * 2;
}

let anotherName = doubleTheSumAsVariable;

const doubleTheSumAsVariableWithLambda =  (x, y) => {
    return (x + y) * 2;
}

/*
*   forEach()
Iterates through an array
    forEach( callbackFunction(currentIteratedValue) )

*/
nums.forEach( (element) => {
    console.log(element);
});

for (let i = 0; i < nums.length; i++) {
    const element = nums[i];
    console.log(element);
}

let sumOfNumbers = 0;
nums.forEach( element => {
    sumOfNumbers += element;
});

console.log(`Sum of Numbrers: ${sumOfNumbers}`);

/*
* Reduce( callbackFunction, startingValue(optional))
    callback function ( currentAccumulatedValue, currentValue) returns the new accumulatedValue
  Reduce returns the final accumulated value
*/
let sumByReduce = nums.reduce((ongoingSum, currentValue) => {
    return ongoingSum + currentValue;
}, 0);

console.log(`Reduced Numbrers: ${sumOfNumbers}`);

const letters = ['A', 'B', 'C', 'D', 'E'];

const finalString = letters.reduce((stringInProgress, letter) => {
    return stringInProgress + ", " + letter;
});

console.log(`Reduced String: ${finalString}`);


/*
    Filter()
*/

const arrayWithoutEvenNumbers = nums.filter( currentNumber => {
    if (currentNumber % 2 != 0) {
        return true;
    } else {
        return false;
    }
});
console.log(`numbers without even: ${arrayWithoutEvenNumbers}`);


const arrayWithoutEvenNumbersUsingTruthy = nums.filter( currentNumber => {
    return currentNumber % 2;
});
console.log(`numbers without even: ${arrayWithoutEvenNumbersUsingTruthy}`);

const products = [
    {
        name: 'book',
        price: 10
    },
    {
        name: 'laptop',
        price: 100
    },
    {
        name: 'milk',
        price: 5
    },
    {
        name: 'compact Disc',
        price: 22
    },
    {
        name: 'shirt',
        price: 25
    }
];

const maxPrice = 24;

const productsUnderMaxPrice = products.filter((currentProduce) =>{
    return currentProduce.price <= maxPrice;
});

/*
  Map()
*/
const lowerCaseArray = letters.map( originalLetter => {
    return originalLetter.toLocaleLowerCase();
})

console.log(`lowercase: ${lowerCaseArray}`);

const productsWithSalePrices = products.map( product => {
    product.price = product.price * .75;
    return product;
});

const fizzArr = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15];
let finalFizzedArray = fizzArr.map( value => {
    if ( !(value % 3) && !(value % 5) ) {
        return 'FizzBuzz';
    }
    if ( !(value % 3) ) {
        return 'Fizz';
    }
    if ( !(value % 5) ) {
        return 'Buzz';
    }
    return value;
});

console.table(finalFizzedArray);

/*
    find()  or findIndex()
*/

/*
 ( value ) => { return value > 0; }
 
 if only 1 parameter then the () are optional, so:
 value => { return value > 0; }
 
 if the function body is one simple line that returns a value then the {} and return is optional, so:
 value => value > 0;
*/
const cdObject = productsWithSalePrices.find( p => p.name === 'compact Disc' );

console.table(cdObject);


// Turn all numbers into a String
const stringConversionFunc = number => {
    return String(number);
};

const arrOfNumsAsStr = nums.map(stringConversionFunc);
console.table(arrOfNumsAsStr);


// Can write our own functions that take an anonymous function

function calculate( func, num1, num2 ){
    return func(num1, num2) * 100;
}

console.log("add: " + calculate( (x, y) => {
    return x + y;
}, 2, 5) );

console.log("divide: " + calculate( (x, y) => {
    return x / y;
}, 2, 5) );

// Function chaining

// For an array of numbers, find the sum of all numbers in the array multipled by 10, but only
// for numbers that are not a multiple of 3

const finalSum = fizzArr.filter( currentValue => {
    if (currentValue % 3 != 0) {
        return true;
    } else {
        return false;
    }
}).map( currentValue => {
    return currentValue * 10;
}).reduce( (sum, currentValue) => {
    return sum + currentValue;
},0);

console.log("chaind result: " + finalSum);