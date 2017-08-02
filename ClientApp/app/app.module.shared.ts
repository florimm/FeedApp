import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { RouterStoreModule } from '@ngrx/router-store';

import { AppContainer } from './containers/App/app.container';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import * as components from './components';
import { HomeContainer } from './containers/home/home.container';
import { FeedSourcesContainer } from './containers/feedSources/feed-sources.container';
import { reducer } from './reducers';
import { FeedSourcesService } from './services/feed-sources.services';
import { FeedEffects } from './effects/feed-sources.effects';


@NgModule({
    declarations: [
        AppContainer,
        FeedSourcesContainer,
        HomeContainer,
        components.NavMenuComponent,
        components.FeedTitleComponent,
        components.FeedItemsComponent,
        components.FeedItemComponent,
        components.FeedImageComponent,
        components.FeedDescriptionComponent,
        components.FeedSourceInputComponent,
        components.FeedSourceItemComponent,
        components.FeedSourceItemsComponent,
        components.StickyFooterComponent,
        components.MasonryComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        StoreModule.provideStore(reducer),
        RouterStoreModule.connectRouter(),
        StoreDevtoolsModule.instrumentOnlyWithExtension(),
        EffectsModule.run(FeedEffects),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeContainer },
            { path: 'feeds/:id', component: HomeContainer },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        FeedSourcesService
    ]
})
export class AppModuleShared {
}
