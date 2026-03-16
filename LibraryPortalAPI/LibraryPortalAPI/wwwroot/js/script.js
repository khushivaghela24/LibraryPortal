const API = "https://localhost:7076/api";

async function register() {

    const user = {
        name: document.getElementById("name").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };

    await fetch(API + "/auth/register", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    });

    alert("Registration Successful");

    window.location = "login.html";
}

async function login() {

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    await fetch(API + "/auth/login", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    window.location = "dashboard.html";
}

async function addBook() {

    const book = {
        title: document.getElementById("title").value,
        author: document.getElementById("author").value,
        quantity: parseInt(document.getElementById("quantity").value)
    };

    const response = await fetch("/api/books", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(book)
    });

    if (response.ok) {
        alert("Book Added Successfully");
        loadBooks();   // reload table
    }
    else {
        alert("Error adding book");
    }
}

async function loadBooks() {

    const response = await fetch("/api/books");

    const books = await response.json();

    const table = document.getElementById("bookTable");

    table.innerHTML = `
    <tr>
        <th>ID</th>
        <th>Title</th>
        <th>Author</th>
        <th>Quantity</th>
    </tr>
    `;

    books.forEach(book => {

        table.innerHTML += `
        <tr>
            <td>${book.id}</td>
            <td>${book.title}</td>
            <td>${book.author}</td>
            <td>${book.quantity}</td>
        </tr>
        `;
    });

}

async function issueBook() {

    const data = {
        userId: document.getElementById("userId").value,
        bookId: document.getElementById("bookId").value
    };

    await fetch(API + "/issuedbooks", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    });

    alert("Book Issued");
}