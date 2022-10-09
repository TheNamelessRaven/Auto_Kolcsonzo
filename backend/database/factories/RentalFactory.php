<?php

namespace Database\Factories;

use App\Models\Car;
use App\Models\Rental;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Rental>
 */
class RentalFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition()
    {
        //$end_date='start_date'.strtotime('+7 days');
        $car=Car::pluck('id');
        return [
            //'id'=>$faker->,
            'car_id'=>$this->faker->randomElement($car),
            'start_date'=>$this->faker->dateTimeInInterval("-3 years","-3 years"),
            'end_date'=>$this->dateTimeInInterval("-3 years","-3 years"),
        ];
    }
}
