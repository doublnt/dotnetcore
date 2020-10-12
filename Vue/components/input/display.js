var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello, vue.'
    }
})
var app2 = new Vue({
    el: '#app-2',
    data: {
        message: 'page loaded' + new Date().toLocaleString()
    }
})
var app3 = new Vue({
    el: '#app-3',
    data: {
        seen: 'true'
    }
})
var app4 = new Vue({
    el: '#app-4',
    data: {
        todos: [
            { text: '1' },
            { text: '2' },
            { text: '3' }
        ]
    }
})
var app5 = new Vue({
    el: '#app-5',
    data: {
        message: "Hello"
    },
    methods: {
        reverseMessage: function () {
            this.message = this.message.split('').reverse().join('')
        }
    }
})
var app6 = new Vue({
    el: '#app-6',
    data: {
        message: "You see see you one day day"
    }
})

Vue.component('todo-item', {
    props: ['todo'],
    template: '<li>{{todo.text}}</li>'
})

var app7 = new Vue({
    el: '#app-7',
    data: {
        groceryList: [
            { id: 0, text: '111' },
            { id: 1, text: '222' },
            { id: 2, text: '333' }
        ]
    }
})

var data = { a: 1 }
var vm = new Vue({
    data: data
})

vm.a = data.a;
vm.a = 2;
data.a

data.a = 3
vm.a