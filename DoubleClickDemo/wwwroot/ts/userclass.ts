class Students
{
    fullName: string;
    constructor(public firstName: string, public middleInitail: string, public lastName: string)
    {
        this.fullName = firstName + middleInitail + lastName;
    }
}

interface Person
{
    firstName: string,
    lastName: string
}

function greeter(person: Person)
{
    return "Hello" + person.firstName + " " + person.lastName;
}

let user = new Students("Jane", "M", "User");

document.body.innerHTML = greeter(user)