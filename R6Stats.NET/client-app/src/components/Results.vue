<template>
  <div id="results">
    <div v-if="results.players === null">
      An error has occurred. Please try again.
    </div>
    <div class="card-columns">
      <b-card v-for="item in results.players" :key="item">
        <b-card-body>
          <b-card-title><router-link :to="{ name: 'PlayerStats', params: { id: item.profile.userId }}">{{item.profile.name}}</router-link></b-card-title>
          <b-card-text>
            Level: {{item.stats.level}}
          </b-card-text>
        </b-card-body>
      </b-card>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class Results extends Vue {
  @Prop() data:any;

  get results() {
    return this.data;
  }
}
</script>