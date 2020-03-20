<template>
  <div id="home">
    <h1>R6Stats.NET</h1>
    <div class="container-fluid">
      <div class="row mx-auto">
        <!-- Search section -->
        <section class="col-sm-12 pt-3 px-0">
          <search @search=onSearch></search>
        </section>
      </div>
     </div>
  </div>
</template>

<script>
//@ is an alias to /src
import { Component, Vue, Prop, Provide } from 'vue-property-decorator'
import Search from "@/components/Search.vue";

@Component({
  components: {
    Search
  }
})

export default class Home extends Vue {
  
  async onSearch(term) {
    // do nothing for now
  }

};
</script>
