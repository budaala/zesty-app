<template>
    <div class="container-md mt-3 mb-5">
        <button class="btn btn-outline-zesty mb-3" @click="loggedIn = !loggedIn">Symulator logowania i wylogowywania</button>
        <div v-if="loggedIn === false">
            <div class="alert alert-zesty" role="alert">
                Aby móc dodawać przepisy, należy się zalogować. Kliknij <router-link class="r-link"
                    to="/logIn">tutaj</router-link>, aby to zrobić.
            </div>
        </div>
        <div v-else>
            <div class="card">
                <div class="card-body">
                    <div class="d-flex justify-content-center">
                        <div class="col-lg-8 col-md-8">
                            <h1 class="mb-3">Dodaj przepis</h1>
                            <div class="row">
                                <div class="col">
                                    <div class="form-floating mb-3">
                                        <input type="text" class="form-control" id="recipeTitle"
                                            placeholder="Podaj nazwę przepisu">
                                        <label for="recipeTitle">Nazwa przepisu</label>
                                    </div>
                                </div>
                                <div class="col">

                                    <div class="form-floating mb-3">
                                        <!-- <label for="recipeCategory" class="form-label">Kategoria</label> -->
                                        <select class="form-select" id="floatingSelect"
                                            aria-label="Floating label select example">
                                            <option selected>Wybierz kategorię</option>
                                            <option value="1">Śniadania</option>
                                            <option value="2">Dania główne</option>
                                            <option value="3">Desery</option>
                                            <option value="4">Napoje</option>
                                            <option value="5">Przekąski</option>
                                            <option value="6">Inne</option>
                                        </select>
                                        <label for="floatingSelect">Kategoria</label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-floating mb-3">
                                <textarea style="height: 100px" class="form-control" id="recipeDescription"
                                    placeholder="Opisz krótko przepis"></textarea>
                                <label for="recipeDescription">Opis przepisu</label>
                            </div>
                            <div class="form-floating mb-3">
                                <textarea style="height: 100px" class="form-control" id="recipeIngredients"
                                    placeholder="Podaj potrzebne składniki"></textarea>
                                <label for="recipeIngredients">Składniki</label>
                            </div>
                            <!-- kroki -->
                            <div class="form-floating mb-3">
                                <textarea style="height: 200px" class="form-control" id="recipeSteps"
                                    placeholder="Podaj kroki"></textarea>
                                <label for="recipeSteps">Kroki</label>
                            </div>
                            <div class="mb-3">
                                <input class="form-control form-control-lg" type="file" id="recipeImage">
                                <!-- <label for="recipeImage" class="form-label mt-0 mb-0"></label>  -->
                            </div>
                            <button type="submit" class="btn btn-outline-zesty me-2">Podgląd</button>
                            <button type="submit" class="btn btn-outline-zesty">Dodaj przepis</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'AddRecipe',
    data() {
        return {
            loggedIn: false
        }
    },
}
</script>

<style scoped>

</style>
