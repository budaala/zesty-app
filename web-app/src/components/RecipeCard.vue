<template>
        <div class="card mb-3">
            <a @click="dosmth">
            <img :src="image" class="card-img-top recipe-img" :alt="name">
            <!-- <img :src="image" class="card-img-top recipe-img" :alt="name"> -->

                <div class="card-body">
                    <h2 class="card-title">{{ name }}</h2>
                    <p class="card-text">{{ description }}</p>
                    <!-- <img src="../assets/logo.png" alt=""> -->
                    <!-- <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p> -->
                </div>
            </a>
        </div>
</template>

<script>
export default {
    name: 'RecipeCard',
    props: {
        id: Number,
        name: String,
        description: String,
        image: String
    },
    methods: {
        dosmth() {
            console.log(this.name);
        }
    }
}
</script>

<style scoped>
.recipe-img {
    height: 200px;
    object-fit: cover;
}

a {
    cursor: pointer;
}
</style>