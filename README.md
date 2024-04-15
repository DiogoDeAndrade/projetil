# PROJÉTIL

Demonstração de como calcular o vector velocidade inicial de um projétil para atingir um alvo.
Assume-se que o projetil tem uma velocidade de saída constante.

Para uma explicação da matemática por trás disto, está aqui um [PDF](Projectile.pdf) com a explicação.

Aqui está a função importante:

```csharp
    bool ComputeVelocity(Vector3 srcPos, Vector3 targetPos, float speed, float gravity, bool minimizeTime, out Vector2 shotVelocty)
    {
        shotVelocty = Vector2.zero;

        float invX = 1.0f;
        float deltaX = targetPos.x - srcPos.x;
        if (deltaX < 0.0f)
        {
            deltaX = -deltaX;
            invX = -1.0f;
        }
        float tmp = gravity * (deltaX * deltaX) / (2.0f * speed * speed);
        float a = tmp;
        float b = deltaX;
        float c = (srcPos.y - targetPos.y + tmp);

        if (Mathf.Abs(a) < 1e-6)
        {
            // Equation is unsolveable
            return false;
        }

        float D = b * b - 4 * c * a;
        if (D < 0.0f)
        {
            // Equation is unsolveable
            return false;
        }
        D = Mathf.Sqrt(D);

        // Two solutions
        float theta1 = Mathf.Atan((-b - D) / (2.0f * a));
        float theta2 = Mathf.Atan((-b + D) / (2.0f * a));

        // Find the times for impact
        float t1 = deltaX / (speed * Mathf.Cos(theta1));
        float t2 = deltaX / (speed * Mathf.Cos(theta2));

        float theta = 0.0f;
        if (t1 < 0.0f)
        {
            if (t2 < 0.0f)
            {
                // Equation is unsolveable
                return false;
            }
            else
            {
                // Only one valid solution
                theta = theta2;
            }
        }
        else
        {
            if (t2 < 0.0f)
            {
                // Only one valid solution
                theta = theta1;
            }
            else
            {
                if (minimizeTime)
                {
                    if (t1 < t2) theta = theta1;
                    else theta = theta2;
                }
                else
                {
                    if (t1 < t2) theta = theta2;
                    else theta = theta1;
                }
            }
        }

        shotVelocty = new Vector2(invX * speed * Mathf.Cos(theta), speed * Mathf.Sin(theta));

        return true;
    }
```

# License

* All source code by Diogo Andrade is licensed under the [MIT] license.

#
# Metadata

* Autor: [Diogo Andrade]

[Diogo Andrade]:https://github.com/DiogoDeAndrade
