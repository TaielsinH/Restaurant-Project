import ApiService from '../core/apiService.js';

const api = new ApiService('http://localhost:5261/api/v1');
const container = document.getElementById('ordersContainer');


const STATUSES = [
  { id: 1, name: "Pending" },
  { id: 2, name: "In progress" },
  { id: 3, name: "Ready" },
  { id: 4, name: "Delivery" },
  { id: 5, name: "Closed" }
];

async function loadOrders() {
  try {
    const orders = await api.getOrders(); 
    const activeOrders = orders.filter(o => o.status.id !== 5);

    renderOrders(activeOrders);
  } catch (err) {
    console.error('Error al cargar órdenes:', err);
    container.innerHTML = `<div class="alert alert-danger">No se pudieron cargar las órdenes.</div>`;
  }
}

function renderOrders(orders) {
  container.innerHTML = '';

  orders.forEach(order => {
    const card = document.createElement('div');
    card.className = 'col-12 col-md-6 col-lg-4';
    card.innerHTML = `
      <div class="card shadow-sm h-100" data-order-id-card="${order.orderNumber}">
        <div class="card-body">
          <h5 class="card-title d-flex justify-content-between align-items-center">
            <span>Orden #${order.orderNumber}</span>
            <span class="badge bg-primary">${order.status.name}</span>
          </h5>
          <p class="text-muted mb-2">Entrega: ${order.deliveryTo}</p>
          <p><strong>Total:</strong> $${order.totalAmount.toFixed(2)}</p>
          <hr>
          <h6>Items:</h6>
          ${order.items.map(item => renderItem(order, item)).join('')}
        </div>
      </div>
    `;
    container.appendChild(card);
  });
}
async function refreshOrder(orderId) {
    try {
      const updatedOrder = await api.getOrderById(orderId);

      
      const card = container.querySelector(`[data-order-id-card="${orderId}"]`);
      if (!card) return;

      
      const badge = card.querySelector('.badge');
      if (badge) badge.textContent = updatedOrder.status.name;

      
      const cardBody = card.querySelector('.card-body');
      const oldItems = cardBody.querySelectorAll('.item-container, h6');
      oldItems.forEach(el => el.remove());

      
      const itemsHTML = `
        <h6>Items:</h6>
        ${updatedOrder.items.map(item => renderItem(updatedOrder, item)).join('')}
      `;

      
      cardBody.insertAdjacentHTML('beforeend', itemsHTML);

    } catch (err) {
      console.error(`[refreshOrder] Error al refrescar orden #${orderId}:`, err);
    }
  }


function renderItem(order, item) {
  return `
    <div class="item-container d-flex align-items-center justify-content-between mb-2">
      <div>
        <strong>${item.dish.name}</strong>
        <small class="d-block text-muted">${item.quantity}x</small>
      </div>
      <select class="form-select form-select-sm w-auto"
        data-order-id="${order.orderNumber}"
        data-item-id="${item.id}">
        ${STATUSES.map(s => `
          <option value="${s.id}" ${s.id === item.status.id ? 'selected' : ''}>${s.name}</option>
        `).join('')}
      </select>
    </div>
  `;
}


container.addEventListener('change', async e => {
  if (e.target.tagName === 'SELECT') {
    const orderId = e.target.dataset.orderId;
    const itemId = e.target.dataset.itemId;
    const newStatus = parseInt(e.target.value);

    try {
      await api._fetch(`/Order/${orderId}/item/${itemId}`, {
        method: 'PATCH',
        body: { status: newStatus }
      });

      e.target.classList.add('border-success');
      setTimeout(() => e.target.classList.remove('border-success'), 1000);
    
      await refreshOrder(orderId);
    } catch (err) {
      console.error('Error al actualizar el estado del item:', err);
      alert('No se pudo actualizar el estado del item.');
    }
  }
});


loadOrders();
