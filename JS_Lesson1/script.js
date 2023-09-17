// Task 1
var userName = prompt("Введите ваше имя:");
alert("Привет, " + userName);

// Task 2
var currentYear = new Date().getFullYear();
var birthYear = prompt("Введите год вашего рождения:");
var userAge = currentYear - birthYear;

alert("Вам " + userAge + " лет.");

// Task 3
var sideLength = prompt("Введите длину стороны квадрата:");
var perimeter = 4 * sideLength;

alert("Периметр квадрата равен " + perimeter);

// Task 4
var radius = prompt("Введите радиус окружности:");
var area = Math.PI * Math.pow(radius, 2);

alert("Площадь окружности равна " + area.toFixed(2));

// Task 5
var distance = prompt("Введите расстояние в км:");
var time = prompt("Введите время:");
var speed = distance / time;

alert("Скорость равна:" + speed.toFixed(2));

// Task 6
var dollar = prompt("Введите сумму в долларах:");
const exchangeRate = 0.93;
var euro = dollar * exchangeRate;

alert("Сумма в евро: " + euro.toFixed(2));

// Task 7
var driveCapacity = prompt("Введите объем флешки в Гб:");
var fileSizeMb = 820;
var filesCount = Math.floor((driveCapacity * 1024) / fileSizeMb);

alert("На флешку поместится " + filesCount);

// Task 8
var walletAmount = prompt("Введите сумму денег:");
var chocolatePrice = prompt("Введите цену одной шоколадки:");
var chocolatesCount = Math.floor(walletAmount / chocolatePrice);
var change = walletAmount % chocolatePrice;

alert("Вы можете купить " + chocolatesCount + ". У вас останется " + change.toFixed(2));

// Task 9
var number = prompt("Введите трехзначное число:");
var reversedNumber = (number % 10) * 100 + Math.floor((number % 100) / 10) * 10 + Math.floor(number / 100);

alert(reversedNumber);

// Task 10
var integerNumber = prompt("Введите целое число:");
var isEven = integerNumber % 2 === 0;

alert("Число " + (isEven ? "четное." : "нечетное."));
