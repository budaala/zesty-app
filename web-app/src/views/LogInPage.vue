<template>
    <div class="container-md mt-5 mb-5">
        <div class="row row-col-lg-2 row-col-1 gx-4">
            <div class="col">
                <log-in></log-in>
            </div>
            <div class="col">
                <register></register>
            </div>
        </div>
    </div>
</template>

<script>
import LogIn from '../components/LogIn.vue';
import Register from '../components/Register.vue';

export default {
    name: 'LogInPage',
    components: {
        LogIn,
        Register
    }
}

</script>

<style scoped></style>