export default class ApiService{
    /**
     * @param
     */
    constructor(baseUrl, options = {})
    {
        this.baseUrl = baseUrl.replace(/\/$/, '');
        this.defaultHeaders = options.headers || { 'Content-Type': 'application/json' };
    }
    async _fetch(path, opts = {})
    {
        const url = `${this.baseUrl}${path.startsWith('/') ? path : '/' + path}`;
        const cfg = 
        {
            headers: { ...this.defaultHeaders, ...(opts.headers || {}) },
            method: opts.method || 'GET',
            body: opts.body ? JSON.stringify(opts.body) : undefined,
        };

        try
        {
            const res = await fetch(url, cfg);
            if (!res.ok)
            {
                const text = await res.text();
                let body;
                try {body = JSON.parse(text);} catch {body = text;}
                throw new Error(`API error ${res.status} ${res.statusText}: ${JSON.stringify(body)}`);
            }
            // si no hay body (204) devolvemos null
            if (res.status == 204) return null;
            return await res.json();
        }
        catch(err)
        {
            console.error('[ApiService] fetch error:', err);
            throw err;
        }
    }
    async getCategories() {
        return await this._fetch('/category');
    }

    async getDishesByCategory(categoryId) {
    const q = categoryId ? `?category=${encodeURIComponent(categoryId)}` : '';
    return await this._fetch(`/dish${q}`);
    }

    async getDishById(id) {
    return await this._fetch(`/dish/${encodeURIComponent(id)}`);
    }

    async getDishes(filters = {})
    {
        try
        {
            const params = {};
            //es para asegurar que los nombres sean lo que espera la URL de la API
            if (filters.categoryId) params.category = filters.categoryId;
            if (filters.name) params.name = filters.name;
            
            const query = new URLSearchParams(params).toString();
            const path = `/dish${query ? '?' + query : ''}`;
            console.log('URL construida: ', `${this.baseUrl}${path}`);
            return await this._fetch(path, {method: 'GET'});
        }
        catch(error)
        {
            console.error(error);
            document.getElementById('dishesGrid').innerText = 'Error al cargar los plaos';
        }
    }
    async selectCategory(categoryId)
    {
        try{
            console.log("Filtrando platos de la categoría:", categoryId);
            console.log("Tipo de categoryId:", typeof categoryId);
            this.view.setActiveCategory(categoryId);
            
            const dishes = await this.service.getDishes({ categoryId });
            this.view.renderDishes(dishes);
        }
        catch(err)
        {
            console.error('MenuController.selectCategory.error', err);
        }
    }
    async getOrders(params = {}) {
        const query = new URLSearchParams(params).toString();
        const url = query ? `/Order?${query}` : '/Order';
        return this._fetch(url);
    }

    async getOrderById(id) {
        return this._fetch(`/Order/${id}`);
    }

    async updateOrder(id, data) {
        return this._fetch(`/Order/${id}`, {
            method: 'PATCH',
            body: data
        });
    }

    //create order
    /**
     * @param {Object} orderData - Datos de la orden
     * {
     *   items: [{ id: Guid, quantity: number, notes: string }],
     *   delivery: { id: number, to: string },
     *   notes: string
     * }
     */
    async createOrder(orderData)
    {
        try
        {
            console.log('[ApiService] Creando orden...', orderData);
            const result = await this._fetch('/order', {
                method: 'POST',
                body: orderData
            });
            console.log('[ApiService] Orden creada correctamente:', result);
            return result;
        }
        catch(err)
        {
            console.error('[ApiService] createOrder.error:', err);
            throw err;
        }
    }
}