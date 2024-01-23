import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';
import App from './App.vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.bundle';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faUser} from '@fortawesome/free-solid-svg-icons'

library.add(faUser)


import RecipeListPage from '../src/views/RecipeListPage.vue';
import LogInPage from '../src/views/LogInPage.vue';
import AddRecipe from '../src/views/AddRecipePage.vue';
import MyRecipes from '../src/views/MyRecipesPage.vue';
import Recipe from '../src/views/RecipePage.vue';

const routes = [
    { path: '/', component: RecipeListPage },
    { path: '/logIn', component: LogInPage },
    { path: '/addRecipe', component: AddRecipe },
    { path: '/myRecipes', component: MyRecipes },
    { name: "RecipePage", path: '/recipes/id=:Id', component: Recipe, props: route => ({ Id: Number(route.params.Id) }) },
    { name: "RecipeListPage", path: '/:RecipeType', component: RecipeListPage, props: true },
    { path: '/recipes/:page', name: 'Recipes', component: RecipeListPage }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

const app = createApp(App);
app.component('font-awesome-icon', FontAwesomeIcon)
app.use(router);
app.mount('#app');