export default {
    data() {
        return {
            currentPage: 1,
            itemsPerPage: 9,
        };
    },
    created() {
        this.currentPage = Number(this.$route.params.page) || 1;
    },
    computed: {
        totalPages() {
            return Math.ceil(this.items.length / this.itemsPerPage);
        },
        pagedItems() {
            const start = (this.currentPage - 1) * this.itemsPerPage;
            const end = start + this.itemsPerPage;
            return this.items.slice(start, end);
        },
    },
    methods: {
        goToPage(page) {
            // if (page >= 1 && page <= this.totalPages) {
            //     this.currentPage = page;
            // }
            if (page >= 1 && page <= this.totalPages) {
                this.$router.push({ name: 'Recipes', params: { page: page } });
            }
        },
    },
    watch: {
        $route(to, from) {
            this.currentPage = Number(to.params.page) || 1;
        },
    },
};