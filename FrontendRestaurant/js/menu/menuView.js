export default class MenuView
{
    constructor()
    {
        this.categoriesEl = document.getElementById('categories');
        this.dishesGrid = document.getElementById('dishesGrid');
        this.modalRoot = document.getElementById('modal-root');
        this.searchInput = document.getElementById('searchBar');

        //callbacks
        this.onCategoryClick = null;
        this.onDishClick = null;
        this.onSearchChange = null;


        this._bind();
    }
    _bind()
    {
        this.categoriesEl.addEventListener('click', (e) => {
            const li = e.target.closest('[data-category-id]');
            if(!li) return;
            const id = li.dataset.categoryId;
            if (this.onCategoryClick) this.onCategoryClick(id);
        });
        this.dishesGrid.addEventListener('click', (e) => {
            const card = e.target.closest('[data-dish-id]');
            if (!card) return;
            const id = card.dataset.dishId;
            if (this.onDishClick) this.onDishClick(id);
        });

        this.searchInput.addEventListener('input', (e) => {
            if (this.onSearchChange) {
                this.onSearchChange(e.target.value);
            }
        });

    }
    //<button class="btn btn-primary rounded-pill px-3" type="button">Primary</button>
    renderCategories(categories)
    {
        this.categoriesEl.innerHTML = '';
        categories.forEach(cat => {
            const div = document.createElement('div');
            div.className = 'category-item';
            const btn = document.createElement('button');
            btn.className = 'btn btn-primary rounded-pill px-3';
            btn.dataset.categoryId = cat.id;
            btn.textContent = cat.name;

            const description = document.createElement('div');
            description.className = 'category-desc';
            description.textContent = cat.description;

            div.appendChild(btn);
            div.appendChild(description);
            this.categoriesEl.appendChild(div);
        });
    }
    setActiveCategory(categoryId)
    {
        const buttons = this.categoriesEl.querySelectorAll('[data-category-id]');
        buttons.forEach((btn) => {
            const isActive = Number(btn.dataset.categoryId) === Number(categoryId);
            btn.classList.toggle('active', isActive);
        });
    }
    renderDishes(dishes)
    {
        this.dishesGrid.innerHTML = '';

        if (!dishes || dishes.length === 0)
        {
            this.dishesGrid.innerHTML = `
                <div class= "col-12 text-center text-muted">
                    <p>No hay platos disponibles.</p>
                </div>
            `;
            return;
        }
        /*
        dishes.forEach(dish => {
            const card = document.createElement('div');
            card.classList.add('dish-card');
            card.dataset.dishId = dish.id;
            const disponible = "Está disponible";
            if(dish.isActive == false)
            {
                disponible = "No está disponible";
            }
            const imageUrl = 
                dish.image && dish.image.startsWith('http')
                ? dish.image    
                : "https://media.istockphoto.com/id/2206210783/photo/large-group-of-raw-food-for-a-well-balanced-diet-includes-carbohydrates-proteins-and-dietary.jpg?s=612x612&w=is&k=20&c=GiMKPRBgUi5XTNJVIeq4iZG0wXOaDcUzl3z0o8V3Ogc=";
            card.innerHTML = `
                <h3>${dish.name}</h3>
                <img src="${imageUrl}" alt="${dish.name}">
                <h5>Precio: $${dish.price}</h5>
                <h5>${disponible}</h5>
                <p>${dish.description}</p>
            `;
            this.dishesGrid.appendChild(card);
        });*/
        dishes.forEach(dish => {
            const col = document.createElement('div');
            col.className = 'col-12 col-sm-6 col-lg-4';

            const disponible = dish.isActive
                ? '<span class="badge bg-success>Disponible</span>'
                : '<span class="badge bg-danger">No Disponible</span>';
            const imageUrl =
                dish.image && dish.image.startsWith('http')
                ? dish.image
                : 'https://media.istockphoto.com/id/2206210783/photo/large-group-of-raw-food-for-a-well-balanced-diet-includes-carbohydrates-proteins-and-dietary.jpg?s=612x612&w=is&k=20&c=GiMKPRBgUi5XTNJVIeq4iZG0wXOaDcUzl3z0o8V3Ogc=';
            col.innerHTML = `
                <div class="card h-100 shadow-sm" data-dish-id="${dish.id}">
                    <img src="${imageUrl}" class="card-img-top" alt="${dish.name}">
                    <div class="card-body d-flex flex-column justify-content-between">
                    <div>
                        <h5 class="card-title">${dish.name}</h5>
                        <p class="card-text text-muted">${dish.description || ''}</p>
                    </div>
                    <div class="mt-3">
                        <p class="fw-bold text-primary mb-2">$${dish.price}</p>
                        <button class="btn btn-outline-primary btn-sm w-100 add-to-order-btn">
                            Agregar
                        </button>
                    </div>
                    </div>
                </div>
            `;
            this.dishesGrid.appendChild(col);
        });
    }

}