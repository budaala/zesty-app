<template>
    <div class="container-md mt-3 mb-5">
        <button class="btn btn-outline-zesty mb-3" @click="loggedIn = !loggedIn">
            Symulator logowania i wylogowywania
        </button>
        <div v-if="loggedIn === false">
            <div class="alert alert-zesty" role="alert">
                Aby móc dodawać przepisy, należy się zalogować. Kliknij
                <router-link class="r-link" to="/logIn">tutaj</router-link>, aby to
                zrobić.
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
                                        <input type="text" class="form-control" v-model="form.recipeTitle"
                                            @blur="setTouched('recipeTitle')"
                                            :class="{ 'is-valid': isValid('recipeTitle'), 'is-invalid': !isValid('recipeTitle') && touched.recipeTitle }"
                                            id="recipeTitle" placeholder="Podaj nazwę przepisu" />
                                        <label for="recipeTitle">Nazwa przepisu</label>
                                        <div v-if="!isValid('recipeTitle') && touched.recipeTitle">
                                            <small class="text-danger">{{ message.recipeTitle }}</small>
                                        </div>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-floating mb-3">
                                        <select class="form-select" v-model="form.recipeType"
                                            @blur="setTouched('recipeType')"
                                            :class="{ 'is-valid': isValid('recipeType'), 'is-invalid': !isValid('recipeType') && touched.recipeType }"
                                            id="floatingSelect" aria-label="Floating label select example">
                                            <option value="" selected>Wybierz kategorię</option>
                                            <option value="1">Śniadania</option>
                                            <option value="2">Dania główne</option>
                                            <option value="3">Desery</option>
                                            <option value="4">Napoje</option>
                                            <option value="5">Przekąski</option>
                                            <option value="6">Inne</option>
                                        </select>
                                        <label for="floatingSelect">Kategoria</label>
                                        <div v-if="!isValid('recipeType') && touched.recipeType">
                                            <small class="text-danger">{{ message.recipeType }}</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-floating mb-3">
                                <textarea style="height: 100px" class="form-control" v-model="form.Description"
                                    @blur="setTouched('Description')"
                                    :class="{ 'is-valid': isValid('Description'), 'is-invalid': !isValid('Description') && touched.Description }"
                                    id="recipeDescription" placeholder="Opisz krótko przepis"></textarea>
                                <label for="recipeDescription">Opis przepisu</label>
                                <div v-if="!isValid('Description') && touched.Description">
                                    <small class="text-danger">{{ message.Description }}</small>
                                </div>
                            </div>
                            <div class="form-floating mb-3">
                                <textarea style="height: 100px" class="form-control" v-model="form.Ingredients"
                                    @blur="setTouched('Ingredients')"
                                    :class="{ 'is-valid': isValid('Ingredients'), 'is-invalid': !isValid('Ingredients') && touched.Ingredients }"
                                    id="recipeIngredients" placeholder="Podaj potrzebne składniki"></textarea>
                                <label for="recipeIngredients">Składniki</label>
                                <div v-if="!isValid('Ingredients') && touched.Ingredients">
                                    <small class="text-danger">{{ message.Ingredients }}</small>
                                </div>
                            </div>
                            <div class="form-floating mb-3">
                                <textarea style="height: 200px" class="form-control" v-model="form.Instructions"
                                    @blur="setTouched('Instructions')"
                                    :class="{ 'is-valid': isValid('Instructions'), 'is-invalid': !isValid('Instructions') && touched.Instructions }"
                                    id="recipeInstructions" placeholder="Podaj instrukcje"></textarea>
                                <label for="recipeInstructions">Instrukcje</label>
                                <div v-if="!isValid('Instructions') && touched.Instructions">
                                    <small class="text-danger">{{ message.Instructions }}</small>
                                </div>
                            </div>
                            <div class="mb-3">
                                <div class="form-floating mb-3">
                                    <input class="form-control form-control-lg" type="file" id="recipeImage"
                                        accept="image/*" @change="handleFileUpload"
                                        :class="{ 'is-valid': isValid('Image') || (isImage === false && touched.Image), 'is-invalid': !isValid('Image') && touched.Image }"
                                        @blur="setTouched('Image')" />
                                    <!-- <label for="recipeImage">Wybierz zdjęcie</label> -->
                                    <div v-if="(!isValid('Image') || isImage === false) && touched.Image">
                                        <small
                                            :class="{ 'text-danger': !isValid('Image'), 'text-warning': isImage === false }">{{
                                                message.Image }}</small>
                                    </div>
                                </div>
                            </div>

                            <button type="submit" class="btn btn-outline-zesty">
                                Dodaj przepis
                            </button>
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
            loggedIn: true,
            form: {
                recipeTitle: '',
                recipeType: '',
                Description: '',
                Ingredients: '',
                Instructions: '',
                Image: ''
            },
            touched: {
                recipeTitle: false,
                recipeType: false,
                Description: false,
                Ingredients: false,
                Instructions: false,
                Image: false
            },
            message: {
                recipeTitle: '',
                recipeType: '',
                Description: '',
                Ingredients: '',
                Instructions: '',
                Image: ''
            },
            isValidImage: false,
            isImage: true
        };
    },
    methods: {
        setTouched(field) {
            this.touched[field] = true;
        },
        validateForm() {
            const { recipeTitle, recipeType, Description, Ingredients, Instructions, Image } = this.form;

            const isValidRecipeTitle = this.validateRecipeTitle(recipeTitle);
            const isValidRecipeType = this.validateRecipeType(recipeType);
            const isValidDescription = this.validateDescription(Description);
            const isValidIngredients = this.validateIngredients(Ingredients);
            const isValidInstructions = this.validateInstructions(Instructions);
            const isValidImage = this.validateImage(Image);

            return isValidRecipeTitle && isValidRecipeType && isValidDescription && isValidIngredients && isValidInstructions && isValidImage;
        },
        isValid(field) {
            const { recipeTitle, recipeType, Description, Ingredients, Instructions, Image } = this.form;

            switch (field) {
                case 'recipeTitle':
                    return this.validateRecipeTitle(recipeTitle);
                case 'recipeType':
                    return this.validateRecipeType(recipeType);
                case 'Description':
                    return this.validateDescription(Description);
                case 'Ingredients':
                    return this.validateIngredients(Ingredients);
                case 'Instructions':
                    return this.validateInstructions(Instructions);
                case 'Image':
                    return this.validateImage(Image);
                default:
                    return true;
            }
        },
        validateRecipeTitle(recipeTitle) {
            if (recipeTitle.trim() === '' || recipeTitle.length < 3) {
                this.message.recipeTitle = 'Nazwa przepisu musi mieć co najmniej 3 znaki';
                return false;
            } else if (recipeTitle.length > 50) {
                this.message.recipeTitle = 'Nazwa przepisu może mieć maksymalnie 50 znaków';
                return false;
            }
            return true;
        },
        validateRecipeType(recipeType) {
            if (recipeType.trim() === '') {
                this.message.recipeType = 'Wybierz kategorię';
                return false;
            }
            return true;
        },
        validateDescription(Description) {
            if (Description.trim() === '' || Description.length < 10) {
                this.message.Description = 'Opis przepisu musi mieć co najmniej 10 znaków';
                return false;
            } else if (Description.length > 500) {
                this.message.Description = 'Opis przepisu może mieć maksymalnie 500 znaków';
                return false;
            }
            return true;
        },
        validateIngredients(Ingredients) {
            if (Ingredients.trim() === '' || Ingredients.length < 10) {
                this.message.Ingredients = 'To pole musi mieć co najmniej 10 znaków';
                return false;
            } else if (Ingredients.length > 500) {
                this.message.Ingredients = 'To pole musi mieć maksymalnie 500 znaków';
                return false;
            }
            return true;
        },
        validateInstructions(Instructions) {
            if (Instructions.trim() === '' || Instructions.length < 10) {
                this.message.Instructions = 'To pole musi mieć co najmniej 10 znaków';
                return false;
            } else if (Instructions.length > 500) {
                this.message.Instructions = 'To pole musi mieć maksymalnie 500 znaków';
                return false;
            }
            return true;
        },
        validateImage(Image) {
            if (this.isValidImage === false) {
                this.message.Image = 'Wybierz plik graficzny. Dozwolone formaty: jpg, jpeg, png.';
                return false;
            }
            else if (!this.isImage) {
                this.message.Image = 'Plik nie został przesłany.';
                return true;
            }
            return true;
        },
        handleFileUpload(event) {
            const file = event.target.files[0];

            if (!file) {
                this.message.Image = 'Nie wybrano pliku.';
                this.isImage = false;
                return;
            }

            const allowedTypes = ['image/jpg', 'image/jpeg', 'image/png'];

            if (!allowedTypes.includes(file.type)) {
                this.message.Image = 'Nieprawidłowy format pliku. Dozwolone są tylko obrazy (jpg, jpeg, png).';
                this.isValidImage = false;
                return;
            }

            this.isValidImage = true;
            this.form.Image = file; // Przypisz plik do formularza, jeśli jest poprawny
        },
    }
};
</script>

<style scoped>
/* Dodaj style, jeśli są wymagane */
</style>
