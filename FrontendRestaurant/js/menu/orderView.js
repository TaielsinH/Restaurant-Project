import ApiService from "../core/apiService.js";

export default class OrderView
{
    constructor()
    {
        this.ordersList = document.getElementById('ordersList');
        this.orderList = document.getElementById('orderList');
        this.deliveryType = document.getElementById('deliveryType');
        this.deliveryTo = document.getElementById('deliveryTo');
        this.orderNotes = document.getElementById('orderNotes');
        this.confirmBtn = document.getElementById('confirmOrderBtn');
        this.deliveryLabel = document.querySelector('label[for="deliveryTo"]');
        this.closeOrdersBtn = document.getElementById('closeOrdersBtn');
        this.ordersModal = document.getElementById('ordersModal');
        this.ordersBtn = document.getElementById('ordersBtn');
        this.orderDetailsSection = document.getElementById('orderDetailsSection');
        this.toggleComandaBtn = document.getElementById('toggleComandaBtn');
        this.closeComandaBtn = document.getElementById('closeComandaBtn');
        this.comandaPanel = document.getElementById('comandaPanel');
        this.comandaCount = document.getElementById('comandaCount');
        this.comandaCount = document.getElementById('comandaCount');
        
        this.items = [];
        this.mode = 'create';
        this.currentOrderId = null;

        this.apiService = new ApiService('http://localhost:5261/api/v1');

        this.toggleComandaBtn.addEventListener('click', () => this.toggleComanda());
        this.closeComandaBtn.addEventListener('click', () => this.toggleComanda(false));
        this.ordersBtn.addEventListener('click', () => this.loadOrders()); 
        this.closeOrdersBtn.addEventListener('click', () => this.ordersModal.classList.add('d-none'));
        this.confirmBtn.addEventListener('click', () => this.confirmOrder());
        this.deliveryType.addEventListener('change', () => this.handleDeliveryTypeChange());
        
        this.handleDeliveryTypeChange();
    }

    toggleComanda(forceOpen = null) {
        const isOpen = this.comandaPanel.classList.contains('open');
        if (forceOpen === false || isOpen) {
            this.comandaPanel.classList.remove('open');
        } else {
            this.comandaPanel.classList.add('open');
        }
    }

    updateComandaCount() {
        this.comandaCount.textContent = this.items.length;
        this.comandaCount.style.display = this.items.length > 0 ? 'inline' : 'none';
    } 

    updateUIForMode() {
        const isEdit = this.mode === 'edit';

        
        this.confirmBtn.textContent = isEdit ? 'Guardar cambios' : 'Confirmar Comanda';

    
        this.confirmBtn.style.display = 'block';

       
        const deliveryFields = this.orderDetailsSection.querySelectorAll(
            '#deliveryType, #deliveryTo, #orderNotes, label[for="deliveryType"], label[for="deliveryTo"], label[for="orderNotes"]'
        );

        deliveryFields.forEach(el => {
            el.closest('.mb-3').style.display = isEdit ? 'none' : 'block';
        }); 
    }
    
    enterCreateMode() {
    this.mode = 'create';
    this.currentOrderId = null;
    this.items = [];
    this.render();
    
    if (this.deliveryType) this.deliveryType.value = '1';
    if (this.deliveryTo) this.deliveryTo.value = '';
    if (this.orderNotes) this.orderNotes.value = '';
    this.updateUIForMode();
    this.handleDeliveryTypeChange();
    }


    async enterEditMode(order) {
        this.mode = 'edit';
        this.currentOrderId = order.orderNumber;
        this.dishCache = this.dishCache || {}; 
        const itemsWithPrices = await Promise.all(
            (order.items || []).map(async i => {
            let dishData;
            
            if (this.dishCache[i.dish.id]) {
                dishData = this.dishCache[i.dish.id];
            } else {
                try {
                dishData = await this.apiService.getDishById(i.dish.id);
                this.dishCache[i.dish.id] = dishData; // guardar en cache
                } catch (err) {
                console.warn(`[OrderView] No se pudo obtener precio de ${i.dish.name}`, err);
                dishData = { price: 0 };
                }
            }

            return {
                id: i.dish.id,
                name: i.dish.name,
                quantity: i.quantity,
                notes: i.notes || '',
                price: dishData.price ?? 0
            };
            })
        );

        this.items = itemsWithPrices;
        this.updateUIForMode();
        this.render();
    }

    
    addDish(dish)
    {
        const existing = this.items.find(i => i.id === dish.id);
        if (existing)
        {
            existing.quantity++;
        }
        else{
            this.items.push({ id: dish.id, 
                              quantity: 1, 
                              notes: '', 
                              name: dish.name,
                              price: dish.price });
        }
        this.render();
    }
    updateItem(id, field, value)
    {
        const item = this.items.find(i => i.id === id);
        if (item) item[field] = value;
    }
    render()
    {
        if (this.items.length === 0)
        {
            this.orderList.innerHTML =`
                <p class="text-muted"> No hay platos seleccionados.</p>
            `;
            return;
        }
        this.orderList.innerHTML = this.items.map(item => `
            <div class ="border-buttom py-2" data-dish-id="${item.id}">
                <div class="d-flex justify-content-between align-items-center">
                    <strong>${item.name}</strong>
                    <span class="text-muted">$${item.price.toFixed(2)}</span>
                </div>
                <div class="d-flex align-items-center my-2">
                    <input type="number" min="1" value="${item.quantity}" class="form-control form-control-sm me-2 quantity-input" style="width:70px;">
                    <input type="text" placeholder="Notas..." value="${item.notes || ''}" class="form-control form-control-sm me-2 notes-input" style="flex:1;">
                    <button class="btn btn-danger btn-sm remove-btn">X</button>
                </div>
            </div>
            `).join('');

            
            const total = this.items.reduce((sum, i) => sum + (i.price * i.quantity), 0)
            this.orderList.innerHTML += `
                <div class="mt-3 text-end">
                    <strong>Total: $${total.toFixed(2)}</strong>
                </div>
            `;
            this.updateComandaCount();
        //acá empieza el binding dinámico de inputs
        this.orderList.querySelectorAll('.quantity-input').forEach(input => {
            input.addEventListener('input', e => {
                const id = e.target.closest('[data-dish-id]').dataset.dishId;
                const value = Number(e.target.value);
                this.updateItem(id, 'quantity', value);
                this.render();
            });
        });

        this.orderList.querySelectorAll('.notes-input').forEach(input => {
            input.addEventListener('input', e => {
                const id = e.target.closest('[data-dish-id]').dataset.dishId;
                const value = e.target.value;
                this.updateItem(id, 'notes', value);
            });
        });

        this.orderList.querySelectorAll('.remove-btn').forEach(btn =>{
            btn.addEventListener('click', e => {
                const id = e.target.closest('[data-dish-id]').dataset.dishId;
                this.items = this.items.filter(i => String(i.id) !== String(id));
                this.render();
                this.updateComandaCount();
            });
        });
    }
    async confirmOrder()
    {
        if (this.items.length === 0){
            alert('Agregá al menos un plato antes de confirmar.');
            return;
        } //modo edit
        if (this.mode === 'edit')
        {
            const payload = {
                items: this.items.map(i => ({
                    id: i.id,
                    quantity: i.quantity,
                    notes: i.notes || ''
                }))
            };
             try {
                await this.apiService.updateOrder(this.currentOrderId, payload);
                alert(`Comanda #${this.currentOrderId} actualizada con éxito`);
               
            } catch (err) {
                console.error('[OrderView] PATCH error:', err);
                alert('No se pudo guardar los cambios de la comanda.');
                }    
            return;
        }
        // modo create
        const deliveryType = Number(this.deliveryType.value);
        let deliveryToValue = String(this.deliveryTo.value).trim();

        if ((deliveryType === 1 || deliveryType === 3) && deliveryToValue === '')
        {
            alert('Por favor, completá el campo "Mesa" o "Dirección" antes de confirmar el pedido')
            return;
        }
        if (deliveryType === 2)
        {
            deliveryToValue = 'Entregar en mostrador para llevar';
            this.deliveryTo.value = deliveryToValue;
        }

        const payload = {
            items: this.items.map(i => ({
                id: i.id,
                quantity: i.quantity,
                notes: i.notes
            })),
            delivery: {
                id: deliveryType,
                to: deliveryToValue
            },
            notes: this.orderNotes.value
        };
        console.log('[OrderView] Payload generado:', payload);
        try
        {
            const result = await this.apiService.createOrder(payload);
            alert(`Comanda creada con éxito (N° ${result.orderNumber ?? ''})`);
            console.log('[OrderView] Respuesta de API:', result);
            this.enterCreateMode(); 
            
        }
        catch(err)
        {
            console.error('[OrderView] Error al crear comanda:', err);
            alert('No se pudo crear la comanda.');
        }

    }
    handleDeliveryTypeChange()
    {
        const selected = Number(this.deliveryType.value);

        if (selected === 1) 
        {
            this.deliveryTo.parentElement.style.display = 'block';
            this.deliveryLabel.textContent = 'Dirección: ';
            this.deliveryTo.placeholder = 'Ej: Calle 893 n2300';
        }
        else if (selected === 3) { 
            this.deliveryTo.parentElement.style.display = 'block';
            this.deliveryLabel.textContent = 'Mesa:';
            this.deliveryTo.placeholder = 'Ej: Mesa 5';
        }
        else { 
            this.deliveryTo.parentElement.style.display = 'none';
        }
    }
    async loadOrders() {
        try {
            const orders = await this.apiService.getOrders();
            const activeOrders = (orders || []).filter(o => o.status?.id !== 5);
            if (!activeOrders || activeOrders.length === 0) {
            this.ordersList.innerHTML = '<p class="text-muted">No hay comandas activas.</p>';
            } else {
                this.ordersList.innerHTML = activeOrders.map(o => `
                    <div class="border-bottom py-2">
                        <strong>Comanda #${o.orderNumber}</strong><br>
                        <small>${new Date(o.createdAt).toLocaleString()}</small><br>
                        <p class="mb-1 text-muted">Tipo: ${o.deliveryType?.name || 'N/A'}</p>
                        <p class="mb-1">Platos: ${
                            (o.items && o.items.length > 0)
                                ? o.items.map(i => i.dish?.name).join(', ')
                                : 'Sin platos'
                        }</p>
                        <p class="mb-1 text-success">Total: $${o.totalAmount.toFixed(2)}</p>
                        <p class="mb-1">
                            Estado: <span class="badge bg-${this._getStatusColor(o.status?.id)}">
                                ${o.status?.name || 'Desconocido'}
                            </span>
                        </p>
                        <div class="text-end mt-1">
                            <button class="btn btn-sm btn-outline-primary" data-order-id="${o.orderNumber}">
                                Editar
                            </button>
                        </div>
                    </div>
                `).join('');    
            }

            this.ordersList.querySelectorAll('[data-order-id]').forEach(btn => {
            btn.addEventListener('click', async e => {
                const id = e.target.dataset.orderId;
                const order = await this.apiService.getOrderById(id);
                if (order.status?.id !== 1)
                {
                   alert('⚠️ No se puede editar una orden que ya fue iniciada o está en preparación.');
                    return; 
                }
                this.enterEditMode(order);
                this.ordersModal.classList.add('d-none');
                this.toggleComanda(true);
                document.getElementById('miComandaCard')?.scrollIntoView({behavior: 'smooth'})
            });
            });

            this.ordersModal.classList.remove('d-none');
        } catch (err) {
            console.error('[OrderView] loadOrders.error', err);
            alert('Error al cargar las comandas');
        }
    }
    _getStatusColor(statusId) {
    switch (statusId) {
        case 1: return 'secondary'; // Pending
        case 2: return 'warning';   // In progress
        case 3: return 'info';      // Ready
        case 4: return 'primary';   // Delivery
        case 5: return 'success';   // Closed
        default: return 'dark';     // Desconocido
    }
}
}