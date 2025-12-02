import ApiService from './core/apiService.js';
import MenuView from './menu/menuView.js';
import OrderView from './menu/orderView.js';
import MenuController from './menu/menuController.js';

document.addEventListener('DOMContentLoaded', async () => {
    const apiService = new ApiService('http://localhost:5261/api/v1');
    const menuView = new MenuView();
    const orderView = new OrderView();

    const menuController = new MenuController(apiService, menuView, orderView);
    await menuController.init();
});