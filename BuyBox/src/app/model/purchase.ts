import {TokenCollection} from './token-collection';
import {SellableItem} from './sellable-item';

export class Purchase {
  canBuy: boolean;
  message: string;
  sellableItem: SellableItem = new SellableItem();
  insertedTokens: TokenCollection = new TokenCollection();
  exchangeTokens: TokenCollection = new TokenCollection();
}
