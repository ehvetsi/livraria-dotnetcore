import apiUrl from "../utils/config"
export default class BooksService {

    listAll() {
        return fetch(`${apiUrl}/books`);
    }

    add(book) {
        return fetch(`${apiUrl}/books`, {
            method: "post",
            body: JSON.stringify(book),
            headers: {
                "Content-Type": "application/json",
            },
        });
    }

    delete(id) {
        return fetch(`${apiUrl}/books/${id}`, {
            method: "delete"
        });
    }

    update(book) {
        return fetch(`${apiUrl}/books/${book.Id}`, {
            method: "put",
            body: JSON.stringify(book),
            headers: {
                "Content-Type": "application/json",
            },
        });
    }

    get(id) {
        return fetch(`${apiUrl}/books/${id}`, {
            method: "get"
        });
    }
}