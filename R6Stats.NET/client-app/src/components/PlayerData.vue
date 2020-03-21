<template>
    <div class="card-columns" >
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">{{item.playerName}}</h5>
        <p class="card-text" v-html="`Current MMR: ${item.playerCurrentMmr}<br/>Current Rank: ${item.playerCurrentRank}`"></p>
        <p class="card-text" v-html="`Maximum MMR: ${item.playerMaxMmr}<br/>Maximum Rank:${item.playerMaxRank}`"></p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class PlayerData extends Vue {
    @Prop() data:any;

    get playerData() {
        return this.data;
    }
}
</script>