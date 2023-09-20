//Task 1
let age = prompt("Введите ваш возраст:");

if (age >= 0 && age <= 2) {
    alert("Вы ребенок");
} else if (age >= 12 && age <= 18) {
    alert("Вы подросток");
} else if (age > 18 && age < 60) {
    alert("Вы взрослый");
} else if (age >= 60) {
    alert("Вы пенсионер");
} else {
    alert("Error");
}

//Task 2
let number = prompt("Введите число от 0 до 9:");

switch (number) {
    case '0':
        alert(")");
        break;
    case '1':
        alert("!");
        break;
    case '2':
        alert("@");
        break;
    case '3':
        alert("#");
        break;
    case '4':
        alert("$");
        break;
    case '5':
        alert("%");
        break;
    case '6':
        alert("^");
        break;
    case '7':
        alert("&");
        break;
    case '8':
        alert("*");
        break;
    case '9':
        alert("(");
        break;
    default:
        alert("Error");
}

//Task 3
let number = prompt("Введите трехзначное число:");

if (number.length !== 3 || isNaN(number)) {
    alert("Error");
} else {
    let digits = number.split("");
    if (digits[0] === digits[1] || digits[1] === digits[2] || digits[0] === digits[2]) {
        alert("В числе есть одинаковые цифры");
    } else {
        alert("В числе нет одинаковых цифр");
    }
}

//Task 4
let year = prompt("Введите год:");

if ((year % 400 === 0) || (year % 4 === 0 && year % 100 !== 0)) {
    alert("Год високосный");
} else {
    alert("Год не високосный");
}

//Task 5
let number = prompt("Введите пятизначное число:");

if (number.length !== 5 || isNaN(number)) {
    alert("Error");
} else {
    let reversedNumber = number.split("").reverse().join("");
    if (number === reversedNumber) {
        alert("палиндромом");
    } else {
        alert(" не является палиндромом");
    }
}

//Task 6
let usdAmount = parseFloat(prompt("Введите сумму в USD:"));

if (isNaN(usdAmount)) {
    alert("Error");
} else {
    let currencyChoice = prompt("Выберите валюту EUR, UAN или AZN:").toUpperCase();

    let convertedAmount;

   switch (currencyChoice) {
        case "EUR":
            convertedAmount = usdAmount * 0.93; 
            break;
        case "UAN":
            convertedAmount = usdAmount * 28.5;
            break;
        case "AZN":
            convertedAmount = usdAmount * 1.7; 
            break;
        default:
            alert("Error");
            break;
    }

    if (convertedAmount !== undefined) {
        alert(`Сумма в ${currencyChoice}: ${convertedAmount.toFixed(2)}`);
    }
}

//Task 7
let purchaseAmount = parseFloat(prompt("Введите сумму покупки:"));

if (isNaN(purchaseAmount)) {
    alert("Error");
} else {
    let discount;

    if (purchaseAmount >= 200 && purchaseAmount < 300) {
        discount = 0.03;
    } else if (purchaseAmount >= 300 && purchaseAmount < 500) {
        discount = 0.05;
    } else if (purchaseAmount >= 500) {
        discount = 0.07;
    } else {
        discount = 0;
    }

    let totalAmount = purchaseAmount - purchaseAmount * discount;
    alert(`Сумма к оплате: ${totalAmount.toFixed(2)}`);
}

//Task 8
let circumference = parseFloat(prompt("Введите длину окружности:"));
let squarePerimeter = parseFloat(prompt("Введите периметр квадрата:"));

if (isNaN(circumference) || isNaN(squarePerimeter)) {
    alert("Error");
} else {
    let circleRadius = circumference / (2 * Math.PI);
    let squareSide = squarePerimeter / 4;

    if (circleRadius <= squareSide) {
        alert("поместиться");
    } else {
        alert("не поместится");
    }
}

//Task 9
let score = 0;

let question1 = prompt("Сколько будет 2 + 2?\n1. 3\n2. 4\n3. 5");
if (question1 === "2" || question1.toLowerCase() === "два") {
    score += 2;
}

let question2 = prompt("Какая столица Азербайджане?\n1. Берлин\n2. Мадрид\n3. Баку");
if (question2 === "3" || question2.toLowerCase() === "баку") {
    score += 2;
}

let question3 = prompt("Чем переносятся данные в HTTP?\n1. Datagram\n2. HyperText\n3. Stream");
if (question3 === "2" || question3.toLowerCase() === "hypertext") {
    score += 2;
}

alert(`Вы набрали ${score} баллов.`);

//Task 10
let day = parseInt(prompt("Введите день:"));
let month = parseInt(prompt("Введите месяц:"));
let year = parseInt(prompt("Введите год:"));

if (isNaN(day) || isNaN(month) || isNaN(year)) {
    alert("Error");
} else {
    let daysInMonth;

    switch (month) {
        case 1: case 3: case 5: case 7: case 8: case 10: case 12:
            daysInMonth = 31;
            break;
        case 4: case 6: case 9: case 11:
            daysInMonth = 30;
            break;
        case 2:
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
                daysInMonth = 29;
            } else {
                daysInMonth = 28;
            }
            break;
        default:
            alert("Error");
            break;
    }

    if (day >= 1 && day <= daysInMonth) {
        if (day === daysInMonth) {
            if (month === 12) {
                day = 1;
                month = 1;
                year++;
            } else {
                day = 1;
                month++;
            }
        } else {
            day++;
        }
        alert(`Следующая дата: ${day}.${month}.${year}`);
    } else {
        alert("Error");
    }
}
