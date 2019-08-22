class SocioService {
    axios
    baseUrl

    constructor(axios, apiUrl) {
        this.axios = axios
        this.baseUrl = `${apiUrl}sociointernacional`
    }

    get(id) {
        let self = this
        return self.axios.get(`${self.baseUrl}/${id}`)
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

export default SocioService