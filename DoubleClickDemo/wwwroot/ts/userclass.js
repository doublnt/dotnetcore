var Students = /** @class */ (function () {
    function Students(firstName, middleInitail, lastName) {
        this.firstName = firstName;
        this.middleInitail = middleInitail;
        this.lastName = lastName;
        this.fullName = firstName + middleInitail + lastName;
    }
    return Students;
}());
function greeter(person) {
    return "Hello" + person.firstName + " " + person.lastName;
}
var user = new Students("Jane", "M", "User");
document.body.innerHTML = greeter(user);
