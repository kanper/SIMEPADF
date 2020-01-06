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
        return this.axios.get(`${this.baseUrl}/${id}`)
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}`)
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl}`, model)
    }

    update(model, id, params) {
        return this.axios.put(`${this.baseUrl}/${id}`, model)
    }

    remove(id, params) {
        return this.axios.delete(`${this.baseUrl}/${id}`)
    }

    executeAction(id, action, params) {
        return null;
    }

    used(id) {
        return this.axios.get(`${this.baseUrl}/used/${id}`)
    }
}

