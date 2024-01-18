<template>
        <div class="card mb-3">
            <a @click="dosmth">
            <img :src="Image" class="card-img-top recipe-img" :alt="Title">
            <!-- <img :src="Image" class="card-img-top recipe-img" :alt="name"> -->

                <div class="card-body">
                    <h2 class="card-title">{{ Title }}</h2>
                    <hr>
                    <p class="card-text">{{ Description }}</p>
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
        Id: Number,
        Title: String,
        Description: String,
        Image: String
    },
    methods: {
        dosmth() {
            console.log(this.Title);
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

.card:hover {
    box-shadow: 0 0 6px rgba(33,33,33,.2); 
    transform: translateY(-7px);
}

</style>