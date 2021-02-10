var number1 = 10;
var number2 = 10.5;

var good = true;

var text1 = 'Он сказал: "Привет". ';
var text2 = " Ban'O nill ";

var empty1 = undefined;
var empty2 = null;

var obj1 = {};
obj1.Age = 123;
obj1.Name = 'Pol';
obj1.SecondName = 'Tol';

var obj2 = {};
obj2.Age = 10;
obj2.Name = 'Maria';
obj2.SecondName = 'Karia';

var fun = function () { };

function anketa(user, calcFullName) {
    console.log('My name ' + user.Name);
    var fullName = calcFullName(user);
    console.log('My full name ' + fullName);
}

anketa(obj1, function (user) {
    return user.Name + ' ' + user.SecondName;
});