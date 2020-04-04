<template>
  <div class="card-columns" >
    <div v-if="result.found === false">
      An error occured.
    </div>
    <h1>{{result.ranked}}</h1>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class PlayerData extends Vue {
  @Prop() data:any;

  get result() {
    return this.data;
  }
}
</script>