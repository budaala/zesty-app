<template>
    <div class="card">
        <div class="card-body">
            <div class="d-flex justify-content-center">
                <div class="col-lg-8 col-md-8">
                    <h1 v-if="editMode" class="mb-3">Edytuj przepis</h1>
                    <h1 v-else class="mb-3">Dodaj przepis</h1>
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
                                <select class="form-select" v-model="form.recipeType" @blur="setTouched('recipeType')"
                                    :class="{ 'is-valid': isValid('recipeType'), 'is-invalid': !isValid('recipeType') && touched.recipeType }"
                                    id="floatingSelect" aria-label="Floating label select example">
                                    <option value="" selected>Wybierz kategorię</option>
                                    <option v-for="mealType in mealTypes" :key="mealType.id"
                                        :value="mealType.id">{{ mealType.name }}</option>
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
                            <input class="form-control form-control-lg" type="file" id="recipeImage" accept="image/*"
                                @change="handleFileUpload" :class="{
                                    'is-valid': isValid('Image') && isImage,
                                    'is-invalid': !isValid('Image') && touched.Image,
                                    'is-warning': !isImage && touched.Image
                                }" @blur="setTouched('Image')" />
                            <!-- <label for="recipeImage">Wybierz zdjęcie</label> -->
                            <div v-if="(!isValid('Image') || !isImage) && touched.Image">
                                <small :class="{ 'text-danger': !isValid('Image'), 'text-warning': !isImage }">{{
                                    message.Image }}</small>
                            </div>
                        </div>
                    </div>
                    <div v-if="formSubmitted">
                        <p :class="{ 'text-danger': !addedRecipe, 'text-success': addedRecipe }">
                            {{ message.all }}
                        </p>
                    </div>
                    <button type="submit" class="btn btn-outline-zesty" @click.prevent="validateForm">
                        {{ editMode ? 'Edytuj przepis' : 'Dodaj przepis' }} </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import recipesService from '../recipesService.js';

export default {
    name: 'RecipeForm',
    props: {
        recipe: Object,
        editMode: Boolean
    },
    data() {
        return {
            form: {
                recipeTitle: '',
                recipeType: '',
                Description: '',
                Ingredients: '',
                Instructions: '',
                Image: ''
            },
            formSubmitted: false,
            addedRecipe: false,
            isImage: false,
            isValidImage: true,
            recipeId: 0,
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
                Image: '',
                all: ''
            },
            mealTypes: []
        }
    },
    mounted() {
        this.getMealTypes();
    },
    methods: {
        setTouched(field) {
            this.touched[field] = true;
        },
        validateForm() {
            this.formSubmitted = true;

            if (this.isValid('recipeTitle') && this.isValid('recipeType') && this.isValid('Description') && this.isValid('Ingredients') && this.isValid('Instructions') && this.isValid('Image')) {
                if (this.editMode) {
                    // this.$emit('edit-recipe', this.form);
                    this.updateRecipe();
                } else {
                    // this.$emit('add-recipe', this.form);
                    this.addedRecipe = true;
                    this.addRecipe();
                    this.message.all = 'Pomyślnie dodano przepis';
                }
            }
            else {
                for (let field in this.touched) {
                    this.setTouched(field);
                    this.isValid(field);
                }
                this.message.all = 'Wypełnij wszystkie pola poprawnie';
            }
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
            // if (recipeType.trim() === '') {
            //     this.message.recipeType = 'Wybierz kategorię';
            //     return false;
            // }
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
        validateImage() {
            if (!this.isValidImage) {
                this.message.Image = 'Nieprawidłowy format pliku. Dozwolone formaty: jpg, jpeg, png.';
                // this.isImage = false;
                return false;
            } else if (this.form.Image) {
                // this.isImage = true;
                this.message.Image = 'Plik załadowany poprawnie.';
                return true;
            } else if (!this.isImage && this.isValidImage) {
                // this.isImage = false;
                this.message.Image = 'Nie wybrano pliku, ale formularz może zostać przesłany.';
                return true;
            }
        },
        handleFileUpload(event) {
            const file = event.target.files[0];
            const allowedTypes = ['image/jpg', 'image/jpeg', 'image/png'];

            if (file) {
                if (!allowedTypes.includes(file.type)) {
                    this.isValidImage = false;
                    this.isImage = false;
                    return;
                }
            }
            else {
                this.isValidImage = true;
                this.isImage = false;
                return;
            }
            
            this.isImage = true;
            this.isValidImage = true;
            this.form.Image = file; // Przypisz plik do formularza, jeśli jest poprawny
            this.validateImage();
        },
        updateRecipe() {
            const apiData = this.getApiData();
            this.editRecipe(apiData);
            // console.log(apiData);
            // console.log(this.recipeId);
            this.$router.push({ name: 'RecipePage', params: { id: this.recipeId } });
        },
        addRecipe() {
            const apiData = this.getApiData();
            // console.log(apiData);
            this.addRecipeApi(apiData);
        },
        async editRecipe(apiData) {
            await recipesService.EditRecipe(this.recipeId, apiData, this.form.Image);
        },
        async addRecipeApi(apiData) {
            await recipesService.AddRecipe(apiData, this.form.Image);
        },
        getApiData() {
            const apiData = {
                Title: this.form.recipeTitle,
                MealTypeId: this.form.recipeType,
                Description: this.form.Description,
                Ingredients: this.form.Ingredients,
                Instructions: this.form.Instructions
            };
            return apiData;
        },
        async getMealTypes()
        {
            this.mealTypes = await recipesService.getMealTypes();
            console.log(this.mealTypes);
            // return this.mealTypes;
        }
    

    },
    watch: {
        recipe: {
            handler(newRecipe) {
                if (newRecipe) {
                    this.recipeId = newRecipe.id;
                    this.form.recipeTitle = newRecipe.title;
                    this.form.recipeType = newRecipe.mealTypeId;
                    this.form.Description = newRecipe.description;
                    this.form.Ingredients = newRecipe.ingredients;
                    this.form.Instructions = newRecipe.instructions;
                }
            },
            immediate: true
        }
    },
}
</script>

<style> .is-warning {
     border-color: #ffc107;
 }
</style>