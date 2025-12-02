import ApiService from "../core/apiService.js";
import OrderView from "./orderView.js";


export default class MenuController{
    /**
     * @param {ApiService} service - instancia que implementa getCategories
     * @param {MenuView} view 
     * @param {OrderView} orderView
     */
    constructor(service, view, orderView)
    {
        this.service = service;
        this.view = view;
        this.orderView = orderView;

        this.activeCategory = null;
        this.searchTerm = '';

        this.view.onCategoryClick = (id) => this.toggleCategory(id);
        this.view.onDishClick = (id) => this.addDishToOrder(id);
        this.view.onSearchChange = (text) => this.searchDishes(text);
    }
    async init()
    {

        try
        {
            const categories = await this.service.getCategories();
            this.view.renderCategories(categories);
            const dishes = await this.service.getDishes();
            this.view.renderDishes(dishes);
        }
        catch(err)
        {
            console.error("MenuController.init.error", err);
        }
    }
    
    async loadDishes()
    {
        try
        {
            const params = {};
            if (this.activeCategory) params.categoryId = this.activeCategory;
            if (this.searchTerm) params.name = this.searchTerm;

            const dishes = await this.service.getDishes(params);
            this.view.renderDishes(dishes);
        }
        catch(err)
        {
            console.error("MenuController.loadDishes.error", err);
        }
    }
    async searchDishes(text)
    {
        try
        {
            this.searchTerm = text.trim();
            await this.loadDishes();
        }
        catch(err)
        {
            console.error("MenuController.searchDishes.error", err);
        }
    }
    async toggleCategory(categoryId)
    {
        try
        {
            const id = Number(categoryId);

            // Si la categoría clickeada ya está activa, deseleccionamos

            if (this.activeCategory === id)
            {
                this.activeCategory = null;
                this.view.setActiveCategory(null); //actualiza la UI
                console.log("Categoría deseleccionada");
            }
            else
            {
                this.activeCategory = id;
                this.view.setActiveCategory(id);
                console.log("Categoria seleccionada", id);
            }
            await this.loadDishes();
        }
        catch(err)
        {
            console.error("MenuController.toggleCategory.error", err);
        }
    }
    async addDishToOrder(dishId)
    {
        try{
            const dish = await this.service.getDishById(dishId);
            this.orderView.addDish(dish);
            console.log(`Plato agregado a la comanda: ${dish.name}`)
        }
        catch(err)
        {
            console.error("MenuController.addDishToOrder.error", err);
        }
    }    
}