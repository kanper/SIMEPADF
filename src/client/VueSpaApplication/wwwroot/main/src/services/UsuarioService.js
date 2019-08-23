class UsuarioService {
    axios
    baseUrl
    ApiUrl

    constructor(axios, apiUrl, authUrl) {
        this.axios = axios
        this.baseUrl = `${apiUrl}usuario`
        this.ApiUrl = `${authUrl}logout`
    }

    get(id) {
        let self = this
        return self.axios.get(`${self.baseUrl}/${id}`)
    }

    logout() {
        let self = this
        return self.axios.get(`${self.ApiUrl}`)
    }

    getAll() {
        let self = this
        return self.axios.get(`${self.baseUrl}`)
    }

    add(model) {
        let self = this
        return self.axios.post(`${self.baseUrl}`, model)
    }

    update(model, id) {
        let self = this
        return self.axios.put(`${self.baseUrl}/${id}`, model)
    }

    remove(id) {
        let self = this
        return self.axios.delete(`${self.baseUrl}-${id}`)
    }
}

export default UsuarioService