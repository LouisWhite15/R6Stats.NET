<template>
<div>
  <b-input-group inline class="d-flex justify-content-center">
    <b-form-input v-model="term" v-on:keyup.enter="search()" type="text" placeholder="Enter Player Name"/>
  </b-input-group>
  <br>
  <b-button variant="primary" @click="search()">Search</b-button>
</div>
</template>

<script lang="ts">
  import { Component, Vue, Provide } from 'vue-property-decorator';

  @Component
  export default class Search extends Vue {
    @Provide() term = '';
    search() {
      this.$emit('search', this.term);
    }
  }
</script>