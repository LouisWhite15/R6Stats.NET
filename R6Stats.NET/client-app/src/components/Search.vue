<template>
  <b-input-group inline class="d-flex justify-content-center">
    <b-form-input v-model="term" type="text" placeholder="Enter Player Name"/>
    <b-button @click="search()">Search</b-button>
  </b-input-group>
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