export default class AbstractService {
    axios;
    baseUrl;

    constructor(axios, baseUrl) {
        if (new.target === AbstractService) {
            throw new TypeError("Cannot construct Abstract instances directly");
        }
        this.axios = axios;
        this.baseUrl = baseUrl;
    }

    get(id, params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.get(`${this.baseUrl}/${id}`)
    }

    getAll(params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.get(`${this.baseUrl}`)
    }

    add(model, params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.post(`${this.baseUrl}`, model)
    }

    update(model, id, params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.put(`${this.baseUrl}/${id}`, model)
    }

    remove(id, params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.delete(`${this.baseUrl}/${id}`)
    }

    executeAction(id, action, params) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return null;
    }

    used(id) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.get(`${this.baseUrl}/used/${id}`)
    }

    removable(id) {
        this.axios.get(`http://localhost:5000/auditoria/user/${window.User.UserId}`);
        return this.axios.get(`${this.baseUrl}/removable/${id}`)
    }
}

