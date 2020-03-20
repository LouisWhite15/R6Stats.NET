<template>
  <b-form inline class="d-flex justify-content-center">
    <!-- Bug in bootstrap-vue - need div around input or button disappears -->
    <div class="col-md-6 col-8 pl-0">
      <b-input v-model="term" class="w-100 mr-sm-2" type="text" placeholder="Enter Player Name"/>
    </div>
    <b-button class="my-2 my-sm-0" @click="search()">Search</b-button>
  </b-form>
</template>

<script lang="ts">
  import { Component, Vue, Provide } from 'vue-property-decorator'
  @Component
  export default class Search extends Vue {
    @Provide()
    term = '';
    search() {
      this.$emit('search', this.term);
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
