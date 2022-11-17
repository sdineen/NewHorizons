export default function User(username, name, token) {
    this.username = username;
    this.name = name;
    this.token = token;
    this.isAuthenticated = token !== undefined;
}
