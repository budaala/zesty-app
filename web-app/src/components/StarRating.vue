<template>
    <div class="star-rating">
        <span class="star-rating-openModal" data-bs-toggle="modal" data-bs-target="#star-rating-modal">
            <span v-for="n in max">&star;</span>
            <div class="star-rating_thisRecipe" :style="{ width: getRatingWidth + '%' }">
                <span v-for="n in max">&starf;</span>
            </div>
        </span>
    </div>
    <span class="m-2">{{ rating }}</span>
    <div class="modal fade" id="star-rating-modal" tabindex="-1" aria-labelledby="starRatingModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="starRatingModalLabel">Oceń przepis</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="star-rating-input">
                        <span class="rateRecipe">
                            <span v-for="(n, index) in max" @click="getUserRating(index)">&star;</span>
                            <div class="star-rating-input_thisRecipe" :style="{ width: getUserRatingWidth + '%' }" >
                                <span v-for="(n, index) in max" @click="getUserRating(index)">&starf;</span>
                            </div>
                        </span>
                    </div>
                    <span class="m-3">{{ userRating }}</span>
                </div>
                <div>
                    <p v-if="submitted">Dziękujemy za ocenę! Możesz teraz zamknąć ten modal.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-dismiss" data-bs-dismiss="modal">Anuluj</button>
                    <button type="button" class="btn btn-outline-zesty" @click.prevent="submitRating()">Oceń</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "StarRating",
    props: {
        max: {
            type: Number,
            default: 5
        },
        rating: {
            type: Number,
            default: 0
        }
    },
    data() {
        return {
            userRating: 0,
            submitted: false
        }
    },
    computed: {
        getRatingWidth() {
            return (this.rating / this.max) * 100;
        },
        getUserRatingWidth() {
            return (this.userRating / this.max) * 100;
        },

    },
    methods: {
        getUserRating(index) {
            this.userRating = Number(index) + 1;
        },
        submitRating() {
            console.log(this.userRating);
            this.submitted = true;
        }
    }
}
</script>

<style>
.star-rating, .star-rating-input {
    display: inline-block;
    color: #7D8A51;
    font-size: 1.2rem;
    position: relative;
}

.star-rating .star-rating_thisRecipe, .star-rating-input .star-rating-input_thisRecipe {
    position: absolute;
    top: 0;
    width: 80%;
    overflow: hidden;
    white-space: nowrap;
}

.star-rating-input {
    font-size: 2rem;
}

.star-rating-openModal, .rateRecipe {
    cursor: pointer;
}


</style>