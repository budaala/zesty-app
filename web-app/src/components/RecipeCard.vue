<template>
    <div class="card mb-3">
        <router-link :to="{ name: 'RecipePage', params: { Id: Id } }">
            <img :src="Image" class="card-img-top recipe-img" :alt="Title">
            <div class="card-body">
                <h2 class="card-title">{{ Title }}</h2>
                <hr>
                <p class="card-text text-truncate" >{{ Description }}</p>
            </div>
        </router-link>
    </div>
</template>

<script>

export default {
    name: 'RecipeCard',
    props: {
        Id: Number,
        Title: String,
        Description: String,
        Image: String
    }
}
</script>

<style scoped>
.recipe-img {
    height: 200px;
    object-fit: cover;
}

.card-title, .card-text, .card a {
    text-decoration: none !important;
    color: #212529;
}

.card-body {
    height: 170px;
}

.card:hover {
    box-shadow: 0 0 6px rgba(33, 33, 33, .2);
    transform: translateY(-7px);
}
</style>