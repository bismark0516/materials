// add pageTitle
let pageTitle = 'My Shopping List'

// add groceries
let groceries = ['apple', 'mango', 'lettuce', 'juice', 'banana', 'watermelon', 'bread', 'milk', 'grapes', 'flour'];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const titleElement = document.getElementById('title');
  titleElement.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const groceriesElement = document.getElementById('groceries');
  groceries.forEach(element => {
    const listItems = document.createElement('li');
    listItems.innerText = element;
    groceriesElement.appendChild(listItems)
  });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() { 
 const list = document.querySelectorAll('li')
 for (let i = 0; i < list.length; i++){
  list[i].classList.add('completed')
 }
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
