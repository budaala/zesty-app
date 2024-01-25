<template>
    <div :class="['alert', `alert-${type}`, 'alert-dismissible']" role="alert">
        <div>{{ message }} </div>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
</template>

<script>
export default {
    name: 'Alert',
    props: {
        type: {
            type: String,
            default: 'success'
        },
        message: {
            type: String,
            default: 'hello'
        }
    }
}
</script>