<template>
  <div class="card-columns" >
    <div class="card" v-for="item in results" :key="item.id">
      <img v-if="item.thumb" class="card-img-top" :src="item.thumb" :alt="item.title" @error="error(item)">
      <div class="card-body">
        <h5 class="card-title">{{item.name}}</h5>
        <p class="card-text" v-html="truncate(item.description || item.abstract, 50)"></p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide } from 'vue-property-decorator'

@Component
export default class Results extends Vue {

  @Prop() data:any;

  get results() {
    return this.data;
  }

  truncate(text:string, limit:number) {
    text = text === undefined ? '' : text;    
    const content = text.split(' ').slice(0, limit);
    return content.join(' ');
  }

  error(item:any) {
    delete item.thumb;
    this.$forceUpdate();
  }
}
</script>