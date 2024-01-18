<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary navbar-dark">
        <div class="container-md">
            <router-link class="navbar-brand" to="/">
                <img src="../assets/logo.png" class="logo">
                Zesty</router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" to="/">Strona główna</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'breakfast' } }">Śniadania</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'main' } }">Dania główne</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'dessert' } }">Desery</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'drink' } }">Napoje</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'snack' } }">Przekąski</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" :to="{ name: 'RecipeListPage', params: { RecipeType: 'other' } }">Inne</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" active-class="active" aria-current="page" to="/myRecipes">Moje przepisy</router-link>
                    </li>
                </ul>
                <div class="d-flex">
                    <router-link class="btn btn-outline-zesty me-2" to="/addRecipe">Dodaj przepis</router-link>
                    <!-- Jeśli zalogowany - ikonka konta, jeśli nie - przycisk zaloguj się / zarejestruj -->
                    <router-link class="btn btn-outline-zesty" to="/logIn">Zaloguj się</router-link>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
export default {
    name: 'Navbar'
}
</script>

<style scoped>
.navbar {
    background-color: #7D8A51  !important;
}
.nav-link.active {
    font-size: large;
    /* text-shadow: 0 0 5px #1A2A15;` */
}
.navbar-brand {
    font-family: "Spectral", serif !important;
    font-weight: 800 !important;
    font-size: 2rem !important;
}

.btn-outline-zesty {
    background-color: #f8f9fa !important;
    color: #1A2A15 !important;
}
.btn-outline-zesty:hover {
    background-color: #1A2A15 !important;
    color: #f8f9fa !important;
}

.logo {
    width: 40px;
    height: 40px;
}
</style>