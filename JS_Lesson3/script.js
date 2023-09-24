//Task 1
let sum = 0;
const start = parseInt(prompt("Enter the start of the range:"));
const end = parseInt(prompt("Enter the end of the range:"));
for (let i = start; i <= end; i++) {
  sum += i;
}
alert(`The sum of numbers in the range [${start}, ${end}] is ${sum}`);


//Task 2
const num1 = parseInt(prompt("Enter the first number:"));
const num2 = parseInt(prompt("Enter the second number:"));

let a = num1;
let b = num2;
while (b !== 0) {
  const temp = b;
  b = a % b;
  a = temp;
}

alert(`The greatest common divisor of ${num1} and ${num2} is ${a}`);

//Task 3
const number = parseInt(prompt("Enter a number:"));
let divisors = [];

for (let i = 1; i <= number; i++) {
  if (number % i === 0) {
    divisors.push(i);
  }
}

alert(`The divisors of ${number} are: ${divisors.join(", ")}`);

//Task 4
const number = parseInt(prompt("Enter a number:"));
const digitCount = number.toString().length;
alert(`The number of digits in ${number} is ${digitCount}`);

//Task 5
let positiveCount = 0;
let negativeCount = 0;
let zeroCount = 0;
let evenCount = 0;
let oddCount = 0;

for (let i = 0; i < 10; i++) {
  const num = parseInt(prompt(`Enter number ${i + 1}:`));
  if (num > 0) {
    positiveCount++;
  } else if (num < 0) {
    negativeCount++;
  } else {
    zeroCount++;
  }

  if (num % 2 === 0) {
    evenCount++;
  } else {
    oddCount++;
  }
}

alert(`Positive numbers: ${positiveCount}\nNegative numbers: ${negativeCount}\nZeroes: ${zeroCount}\nEven numbers: ${evenCount}\nOdd numbers: ${oddCount}`);

//Task 6
do {
    const num1 = parseFloat(prompt("Enter the first number:"));
    const operator = prompt("Enter an operator (+, -, *, /):");
    const num2 = parseFloat(prompt("Enter the second number:"));
  
    let result;
    switch (operator) {
      case "+":
        result = num1 + num2;
        break;
      case "-":
        result = num1 - num2;
        break;
      case "*":
        result = num1 * num2;
        break;
      case "/":
        if (num2 !== 0) {
          result = num1 / num2;
        } else {
          alert("Division by zero is not allowed.");
        }
        break;
      default:
        alert("Invalid operator.");
    }
  
    if (result !== undefined) {
      alert(`Result: ${result}`);
    }
  
    const again = prompt("Do you want to perform another calculation? (yes/no)").toLowerCase();
  } while (again === "yes");
  
//Task 7
const number = prompt("Enter a number:");
const positions = parseInt(prompt("Enter the number of positions to shift:"));

const shiftedNumber = parseInt(number.slice(positions) + number.slice(0, positions));
alert(`Shifted number: ${shiftedNumber}`);

//Task 8
let dayOfWeek = 0;
const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

do {
  alert(`${days[dayOfWeek]}. Do you want to see the next day?`);
  dayOfWeek = (dayOfWeek + 1) % 7;
} while (confirm("Show the next day?"));

//Task 9
for (let i = 2; i <= 9; i++) {
    for (let j = 1; j <= 10; j++) {
      const result = i * j;
      console.log(`${i} x ${j} = ${result}`);
    }
  }
  
//Task 10
let min = 0;
let max = 100;

alert("Enter number between 0 and 100.");

while (min <= max) {
  const guess = Math.floor((min + max) / 2);
  const userFeedback = prompt(`Is your number > ${guess}, < ${guess}, or == ${guess}?`).toLowerCase();

  if (userFeedback === "==") {
    alert(`Your number is ${guess}.`);
    break;
  } else if (userFeedback === ">") {
    min = guess + 1;
  } else if (userFeedback === "<") {
    max = guess - 1;
  } else {
    alert("Please enter >, <, or ==.");
  }
}
